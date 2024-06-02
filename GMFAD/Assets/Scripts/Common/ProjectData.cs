using Common.Utils;

namespace Common
{
    public class ProjectData
    {
        public class Layers : Enumeration<Layers>
        {
            public static readonly Layers Default = new Layers(0, "Default");
            public static readonly Layers TransparentFX = new Layers(1, "TransparentFX");
            public static readonly Layers IgnoreRaycast = new Layers(2, "Ignore Raycast");
            public static readonly Layers Water = new Layers(4, "Water");
            public static readonly Layers UI = new Layers(5, "UI");
            public static readonly Layers Player = new Layers(6, "Player");
            public static readonly Layers Interactable = new Layers(7, "Interactable");

            protected Layers(int value, string name) : base(value, name) { }
        }
        
        public class Tags : Enumeration<Tags>
        {
            public static readonly Tags Player = new Tags(0, "Player");
            public static readonly Tags Interactable = new Tags(1, "Interactable");
            public static readonly Tags UI_RecruitmentOption = new Tags(2, "UI_RecruitmentOption");
            protected Tags(int value, string name) : base(value, name) { }

            
        }
        
        public class Scenes : Enumeration<Scenes>
        {
            public static readonly Scenes GameScene = new Scenes(0, "GameScene");
            public static readonly Scenes TitleScreen = new Scenes(1, "TitleScreen");
            protected Scenes(int value, string name) : base(value, name) { }
        }
    }
}