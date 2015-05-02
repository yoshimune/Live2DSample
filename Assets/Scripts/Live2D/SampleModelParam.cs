using UnityEngine;
using System.Collections;
using live2d;
using live2d.framework;

namespace SampleModel{
    public class SampleModelParam {
        private ParamDefFloat param;
        private float targetParam;
        private float currentParam;
        private float delay;
        private float delta;

        public SampleModelParam(ParamDefFloat param) {
            this.param = param;
            this.targetParam = param.getMaxValue();
            this.currentParam = param.getDefaultValue ();
            this.delay = 0;
        }

        public ParamDefFloat Param {
            set { this.param = value; }
            get { return this.param; }
        }

        public float TargetParam {
            set { this.targetParam = value; }
            get { return this.targetParam; }
        }

        public float CurrentParam {
            set { this.currentParam = value; }
            get { return this.currentParam; } 
        }

        public float Delay {
            set { this.delay = value;
                this.setDelta(); }
            get { return this.delay; }
        }

        public float Delta {
            //set { this.delta = value; }
            get { return this.delta; }
        }

        public void setDelta(){
            float weight = 1.0f;
            if ( this.delay > 0 ) { weight = Time.deltaTime / this.delay; }
            this.delta = (this.targetParam - this.currentParam) * weight;
        }
    }
}