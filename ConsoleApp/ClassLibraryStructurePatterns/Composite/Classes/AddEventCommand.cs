using ClassLibraryBehavioralPatterns.Command;
using ClassLibraryBehavioralPatterns.Observer;
namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class AddEventCommand : ICommand
    {
        private readonly EventTarget _eventTarget;
        private readonly string _eventName;
        private readonly IEventListener _listener;
        public AddEventCommand(EventTarget eventTarget, string eventName, IEventListener listener)
        {
            _eventTarget = eventTarget;
            _eventName = eventName;
            _listener = listener;
        }
        public void Execute()
        {
            _eventTarget.AddEventListener(_eventName, _listener);
        }
        public void Undo()
        {
            _eventTarget.RemoveEventListener(_eventName, _listener);
        }
    }
}
