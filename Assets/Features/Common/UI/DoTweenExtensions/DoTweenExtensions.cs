using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Common.UI.DoTweenExtensions
{
    public static class DoTweenExtensions
    {
        public static async UniTask TweensToTask(params Tween[] tweens)
        {
            var completion = new UniTaskCompletionSource();

            var sequence = DOTween.Sequence();

            foreach (var tween in tweens)
                sequence.Append(tween);

            sequence.AppendCallback(() => { completion.TrySetResult(); });

            await completion.Task;
        }
    }
}