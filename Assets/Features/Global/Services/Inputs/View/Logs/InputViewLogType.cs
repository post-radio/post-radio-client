namespace Global.Inputs.View.Logs
{
    public enum InputViewLogType
    {
        LeftMouseButtonDown,
        LeftMouseButtonUp,
        RightMouseButtonDown,
        RightMouseButtonUp,
        MouseMoved,

        BeforeRebind,
        AfterRebind,

        ConstraintAdded,
        ConstraintReduced,
        ConstraintRemoved,
        ConstraintBelowZeroException,
        InputCanceledWithConstraint
    }
}