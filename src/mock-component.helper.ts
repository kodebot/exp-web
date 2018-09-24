import { Component, forwardRef } from '@angular/core';
import { DefaultValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

export function createMockComponent(selector: string, inputs?: string[]) {
    const options: Component = {
        selector: selector,
        template: '',
        inputs: inputs
    };

    return Component(options)(class MockComponent { });
}


export function createMockFormControlComponent(selector: string, inputs?: string[]): any {
    class MockFormControlComponent extends DefaultValueAccessor {
        value: any = '';
        writeValue(val: any) {
            this.value = val;
            super.writeValue(val);
        }
    }

    const options: Component = {
        selector: selector,
        template: '',
        inputs: inputs,
        providers: [{
            provide: NG_VALUE_ACCESSOR,
            multi: true,
            useExisting: forwardRef(() => MockFormControlComponent),
        }]
    };

    return Component(options)(MockFormControlComponent);
}