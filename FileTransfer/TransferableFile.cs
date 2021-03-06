﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Common.FileTransfer
{



    ////////////////////////////////////////////////////////////////////////////
    ///
    /// <summary>Class that represents a transferable file.</summary>
    ///
    ////////////////////////////////////////////////////////////////////////////

    public abstract class TransferableFile:
        ITransferableFile
    {

        /// <summary>Creates a new instance of the <see cref="TransferableFile" /> type.</summary>
        protected TransferableFile()
        { }

        /// <summary>Gets a stream to the content of the file.</summary>
        /// <remarks>It is the responsibility of the caller to <see cref="Stream.Dispose()" /> the returned stream.</remarks>
        public abstract Task<Stream> GetContentAsync();

        /// <summary>Asynchronously reads the bytes from the current stream and writes them to another stream.</summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        public abstract Task CopyContentToAsync(Stream destination);

        /// <summary>Gets the length of the transferable file.</summary>
        public abstract Task<long?> GetLengthAsync();

        /// <summary>Gets the MIME type associated with the transferable file.</summary>
        /// <returns>The MIME type associated with the transferable file.</returns>
        public abstract Task<string> GetMimeTypeAsync();

        /// <summary>Gets or sets the MIME type of the transferable file.</summary>
        public virtual string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _Name=Path.GetRandomFileName();
                else
                    _Name=value;
            }
        }

        private string _Name;
    }
}
