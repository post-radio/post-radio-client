namespace Menu.Common.Tasks.Abstract
{
    public interface IProgressionTask
    {
        int Value { get; }
    }

    public abstract class ProgressionTask : IProgressionTask
    {
        public ProgressionTask(int value)
        {
            _value = value;
        }
        
        private readonly int _value;

        public int Value => _value;
    }
}