namespace BlazorInventor.Model
{
    public class SurveyQuestion
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? NumericResponse { get; set; } // Nullable int to handle unanswered questions
    }
}
