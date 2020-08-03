using System.ComponentModel;

namespace DuplaImage.API {
    public class PropertyModel {
        [Category("App")]
        public Skin AppSkin { get; set; }
        [Category("Scanner")]
        public Level ScanLevel { get; set; }
    }

    public enum Skin {
        Light,
        Dark,
        Violet
    }

    public enum Level {
        loose,
        standard,
        high
    }
}
