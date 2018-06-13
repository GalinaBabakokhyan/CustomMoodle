namespace CustomMoodle.Models
{
    public class AlertViewModel 
    {
       
        public AlertType Type { get; set; }
        public string AlertTitle { get; set; }
        public string AlertMessage { get; set; }
        public AlertViewModel(AlertType type, string title, string message)
        {
            Type = type;
            AlertTitle = title;
            AlertMessage = message;
        }
    }

}