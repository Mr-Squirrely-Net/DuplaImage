using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuplaImage.Lib;

namespace DuplaImage.API {
    public class DImage {

        public string ImageName { get; set; }
        public string ImageDir { get; set; }
        public ulong ImageHash { get; set; }
        public bool IsDup { get; set; } = false;
        public List<DImage> SimilarTo { get; } = new List<DImage>();

        public void IsSimilarTo(List<DImage> images) {
            foreach (DImage image in images.Where(image => ImageHashes.CompareHashes(ImageHash, image.ImageHash) == 1.0f)) {
                if (image != this) {
                    SimilarTo.Add(image);
                }
            }
        }

    }
}
