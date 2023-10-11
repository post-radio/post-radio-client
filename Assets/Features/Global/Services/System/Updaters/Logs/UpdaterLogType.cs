namespace Global.System.Updaters.Logs
{
    public enum UpdaterLogType
    {
        PreUpdatableAdd,
        PreUpdatableRemove,
        PreUpdateCalled,

        UpdatableAdd,
        UpdatableRemove,
        UpdateCalled,

        PreFixedUpdatableAdd,
        PreFixedUpdatableRemove,
        PreFixedUpdateCalled,

        FixedUpdatableAdd,
        FixedUpdatableRemove,
        FixedUpdateCalled,

        PostFixedUpdatableAdd,
        PostFixedUpdatableRemove,
        PostFixedUpdateCalled,

        GizmosUpdatableAdd,
        GizmosUpdatableRemove,
        GizmosUpdatableCalled,

        SpeedModified,
        SpeedModifyError,
        SpeedModifiableAdd,
        SpeedModifiableRemove
    }
}