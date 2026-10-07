using Microsoft.Maui.Controls;

using MauiView = Microsoft.Maui.Controls.View;

#if ANDROID
using Android.Views;
using AndroidView = Android.Views.View;
#endif

namespace HorizonShopping.Maui.Behaviors
{
    public class LongPressBehavior : Behavior<MauiView>
    {
        private CancellationTokenSource? _cancellationTokenSource;

#if ANDROID
        private AndroidView? _nativeView;
#endif

        public event EventHandler? LongPressed;

        //ASOCIACIÓN Y DESASOSIACIÓN
        protected override void OnAttachedTo(MauiView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.HandlerChanged += OnHandlerChanged;
        }

        protected override void OnDetachingFrom(MauiView bindable)
        {
            bindable.HandlerChanged -= OnHandlerChanged;

#if ANDROID
            if (_nativeView is not null)
            {
                _nativeView.Touch -= OnTouch;
                _nativeView = null;
            }
#endif

            CancelarPulsacion();

            base.OnDetachingFrom(bindable);
        }

        private void OnHandlerChanged(object? sender, EventArgs e)
        {
#if ANDROID
            if (sender is MauiView view && view.Handler?.PlatformView is AndroidView nativeView)
            {
                _nativeView = nativeView;

                _nativeView.Touch -= OnTouch;
                _nativeView.Touch += OnTouch;
            }
#endif
        }

        //GESTIÓN DE LA PULSACIÓN
#if ANDROID
        private void OnTouch(object? sender, AndroidView.TouchEventArgs e)
        {
            switch (e.Event?.ActionMasked)
            {
                case MotionEventActions.Down:
                    IniciarPulsacionLarga();
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Cancel:
                    CancelarPulsacion();
                    break;
            }

            e.Handled = false;
        }
#endif

        private async void IniciarPulsacionLarga()
        {
            CancelarPulsacion();

            _cancellationTokenSource =
                new CancellationTokenSource();

            try
            {
                await Task.Delay(
                    700,
                    _cancellationTokenSource.Token);

                LongPressed?.Invoke(this, EventArgs.Empty);
            }
            catch (TaskCanceledException)
            {
                // La pulsación terminó antes de los 700 ms.
            }
        }

        private void CancelarPulsacion()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}