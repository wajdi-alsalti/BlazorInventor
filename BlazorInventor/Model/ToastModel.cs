namespace BlazorInventor.Model
{
    public class ToastModel
    {
        public string ToastHeader { get; set; } = "Toast Header";
        public string ToastMessage { get; set; } = "Toast Message";
        public string ToastBG { get; set; } = "success";
        public int Delay { get; set; } = 3000;
        public string Position { get; set; } = "top-0 end-0";
    }
}
