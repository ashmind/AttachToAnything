using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ExceptionBreaker.Implementation;
using Microsoft.VisualStudio.Shell.Interop;

namespace AttachToAnything.Internal {
    /// <summary>
    /// Normally this logs both to Trace of the debugging Visual Studio
    /// and Output window for the target Visual Studio. However 
    /// for this project I haven't yet sorted the question with getting
    /// an output window pane. 
    /// </summary>
    public class DiagnosticLogger : IDiagnosticLogger {
        //private readonly IVsOutputWindowPane _output;
        private readonly string _traceCategory;

        public DiagnosticLogger(/*IVsOutputWindowPane output,*/ string traceCategory) {
            //_output = output;
            _traceCategory = traceCategory;
        }

        public void WriteLine(string message) {
            //_output.OutputString(message + Environment.NewLine);
            Trace.WriteLine(message, _traceCategory);
        }

        public void WriteLine(string format, params object[] args) {
            WriteLine(string.Format(format, args));
        }
    }
}
