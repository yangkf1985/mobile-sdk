/*
 * Copyright (c) 2016 CartoDB. All rights reserved.
 * Copying and using this code is allowed only according
 * to license terms, as given in https://cartodb.com/terms/
 */

#ifndef _CARTO_CAMERAEVENT_H_
#define _CARTO_CAMERAEVENT_H_

#include <cglib/vec.h>
#include <cglib/mat.h>

namespace carto {
    class Options;
    class ViewState;
    
    class CameraEvent {
    public:
        virtual ~CameraEvent() { }
    
        virtual void calculate(Options& options, ViewState& viewState) = 0;
    
    protected:
        CameraEvent() { }

        static void ClampFocusPos(cglib::vec3<double>& focusPos, cglib::vec3<double>& cameraPos, cglib::vec3<double>& upVec, const Options& options, ViewState& viewState);
    };
    
}

#endif
