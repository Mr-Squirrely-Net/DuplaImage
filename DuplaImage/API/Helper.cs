using System;
using System.Collections.Generic;
using System.Text;
using DuplaImage.Lib;

namespace DuplaImage.API {
    public static class Helper {
        public static ImageHashes ImageHasher = new ImageHashes(new ImageMagickTransformer());
    }
}
