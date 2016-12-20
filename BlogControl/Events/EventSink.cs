using BlogControl.ApiService;
using BlogControl.Events;

namespace BlogControl.Events
{
    public static class EventSink
    {
        public static event OnLoginHandler Login;

        public static void InvokeLogin(LoginEventArgs args)
        {
            Login?.Invoke(args);
        }
    }
}