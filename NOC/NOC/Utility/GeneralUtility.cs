﻿using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NOC.Utility
{
    public class GeneralUtility
    {
        public static async Task<byte[]> getByteArrayFromFile(FileResult pickedfile)
        {
            var bytes = default(byte[]);
            try
            {
                var st = await pickedfile.OpenReadAsync();
                using (var streamReader = new StreamReader(st))
                {
                    using (var memstream = new MemoryStream())
                    {
                        streamReader.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return bytes;
        }
    }
}
