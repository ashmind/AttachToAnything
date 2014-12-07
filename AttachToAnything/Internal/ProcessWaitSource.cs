using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExceptionBreaker.Implementation;

namespace AttachToAnything.Internal {
    public class ProcessWaitSource {
        private readonly IDiagnosticLogger _logger;

        public ProcessWaitSource(IDiagnosticLogger logger) {
            _logger = logger;
            IsEfficient = true;
        }

        public bool IsEfficient { get; private set; }

        public Task WaitForAsync(string name, CancellationToken cancellationToken) {
            _logger.WriteLine("Attempting {0} wait.", IsEfficient ? "efficient" : "inefficient");
            
            var taskSource = new TaskCompletionSource<object>();
            var query = IsEfficient 
                      ? new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName = '" + name + "'")
                      : new EventQuery("SELECT TargetInstance FROM __InstanceCreationEvent WITHIN 0.5 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name LIKE '" + name + "'");

            ManagementEventWatcher watcher = null;
            try {
                watcher = new ManagementEventWatcher(query);
                cancellationToken.Register(() => {
                    _logger.WriteLine("Received Cancel while waiting for '{0}'.", name);
                    watcher.Stop();
                    watcher.Dispose();
                    taskSource.TrySetCanceled();
                });
                watcher.EventArrived += (sender, e) => {
                    _logger.WriteLine("Received process start event for '{0}'.", name);
                    watcher.Stop();
                    watcher.Dispose();
                    taskSource.TrySetResult(null);
                };

                try {
                    watcher.Start();
                }
                catch (ManagementException) {
                    if (!IsEfficient)
                        throw;

                    watcher.Dispose();
                    IsEfficient = false;
                    return WaitForAsync(name, cancellationToken);
                }
            }
            catch (Exception) {
                if (watcher != null)
                    watcher.Dispose();
                throw;
            }

            return taskSource.Task;
        }
    }
}
