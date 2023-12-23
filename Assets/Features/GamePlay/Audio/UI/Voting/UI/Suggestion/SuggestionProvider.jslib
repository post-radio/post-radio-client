mergeInto(LibraryManager.library,
    {
        GetClipboard: function () {
            return navigator.clipboard.readText();
        }
    }
);