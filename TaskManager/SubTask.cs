namespace TaskManager
{
    public class SubTask
    {
        public int Id { get; }
        public string Info { get; }
        private bool _isCompleted = false;

        public SubTask(int id, string information)
        {
            this.Id = id;
            this.Info = information;
        }
        
        public void MarkCompleted()
        {
            _isCompleted = true;
        }
    }
}