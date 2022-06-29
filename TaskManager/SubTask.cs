namespace TaskManager
{
    public class SubTask
    {
        private int _id;
        private string _information;
        private bool _isCompleted = false;

        public int Id => _id;
        public string Info => _information;

        public SubTask(int id, string information)
        {
            _id = id;
            _information = information;
        }
        
        public void MarkCompleted()
        {
            _isCompleted = true;
        }
    }
}