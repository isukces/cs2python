namespace Lang.Python.Plot
{
    public class Line2D
    {
        [DirectCall("aname")]
        public string AName { get; }
        
        
        [DirectCall("axes")]
        public AxesSubplot Axes { get; }
        
    }
}