using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.Shell;

namespace AttachToAnything.Internal {
    // https://github.com/ryanmolden/MPF-DynamicItemStart-Example/blob/master/DynamicStartItemExamplePackage/DynamicItemMenuCommand.cs
    public class DynamicMenuCommand : OleMenuCommand {
        private readonly Func<int, string> _getText;

        public DynamicMenuCommand(EventHandler invokeHandler, CommandID rootId, Func<int, string> getText)
            : base(invokeHandler, null /*changeHandler*/, BeforeQueryStatusCallback, rootId)
        {
            _getText = getText;
        }

        private static void BeforeQueryStatusCallback(object sender, EventArgs e) {
            var that = (DynamicMenuCommand)sender;
            that.Enabled = true;
            that.Visible = true;
            that.Text = that._getText(that.MatchedCommandId > 0 ? that.MatchedCommandId - that.CommandID.ID : 0);

            //Clear this out here as we are done with it for this item.
            that.MatchedCommandId = 0;
        }

        public override bool DynamicItemMatch(int cmdId) {
            //If getText does not return null, this means there should be a command with this index
            //otherwise clear our any previously remembered matched command id and return that it is not a match.
            if (_getText(cmdId - CommandID.ID) != null) {
                MatchedCommandId = cmdId;
                return true;
            }

            MatchedCommandId = 0;
            return false;
        }
    }
}
