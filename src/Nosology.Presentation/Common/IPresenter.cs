
namespace Escyug.Nosology.Presentation.Common
{
    public interface IPresenter<TView>
        where TView : IView
    {
        void InjectView(TView view);
    }
}
