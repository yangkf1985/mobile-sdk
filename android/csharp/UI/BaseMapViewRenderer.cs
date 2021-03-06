﻿namespace Carto.Ui {
    using System;
    using Javax.Microedition.Khronos.Egl;
    using Javax.Microedition.Khronos.Opengles;
    using Android.Opengl;

    // GLSurfaceView.IRenderer implementation for MapView
    internal class BaseMapViewRenderer : Java.Lang.Object, GLSurfaceView.IRenderer {
        private WeakReference<BaseMapView> _baseMapView;

        public BaseMapViewRenderer(BaseMapView baseMapView) {
            _baseMapView = new WeakReference<BaseMapView>(baseMapView);
        }

        public void Detach() {
            lock (this) {
                _baseMapView.SetTarget(null);
            }
        }

        public void OnSurfaceCreated(IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config) {
            lock (this) {
                BaseMapView baseMapView = null;
                _baseMapView.TryGetTarget(out baseMapView);
                if (baseMapView != null) {
                    baseMapView.OnSurfaceCreated();
                }
            }
        }

        public void OnSurfaceChanged(IGL10 gl, int width, int height) {
            lock (this) {
                BaseMapView baseMapView = null;
                _baseMapView.TryGetTarget(out baseMapView);
                if (baseMapView != null) {
                    baseMapView.OnSurfaceChanged(width, height);
                }
            }
        }

        public void OnDrawFrame(IGL10 gl) {
            lock (this) {
                BaseMapView baseMapView = null;
                _baseMapView.TryGetTarget(out baseMapView);
                if (baseMapView != null) {
                    baseMapView.OnDrawFrame();
                }
            }
        }
    }
}
