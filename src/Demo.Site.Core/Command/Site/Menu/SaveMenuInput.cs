﻿using System.Collections.Generic;

namespace Demo.Business.Command.Site.Menu
{
    public class SaveMenuInput
    {
        public IList<MenuItem> MenuItems { get; set; }
        public IList<MenuItem> PrivateMenuItems { get; set; }
        public IList<MenuItem> BottomMenuItems { get; set; }
        public CurrentRequest Site { get; set; }
    }
}