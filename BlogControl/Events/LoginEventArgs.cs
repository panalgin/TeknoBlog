using BlogControl.ApiService;
using System;

namespace BlogControl
{
    public class LoginEventArgs
    {
        public UserEx User { get; set; }
        public DateTime OccuredAt { get; set; }
    }
}