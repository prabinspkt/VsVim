﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Platform.WindowManagement;
using Microsoft.VisualStudio.PlatformUI.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text;

namespace Vim.VisualStudio.Specific
{
#if VS_SPECIFIC_2012 || VS_SPECIFIC_2013 || VS_SPECIFIC_2015

    internal partial class SharedService
    {
        private IEnumerable<VirtualSnapshotPoint> GetCarets(ITextView textView)
        {
            return new[] { textView.Caret.Position.VirtualBufferPosition };
        }
    }

#else

    internal partial class SharedService
    {
        private IEnumerable<VirtualSnapshotPoint> GetCarets(ITextView textView)
        {
            return
                textView
                .GetMultiSelectionBroker()
                .AllSelections
                .Select(selection => selection.InsertionPoint);
        }
    }

#endif
}
