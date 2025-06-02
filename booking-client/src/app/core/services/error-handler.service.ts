import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})


export class ErrorHandlerService {
    public formErrors: Record<string, string[]> = {};
    public generalErrors: string[] = [];
    public errorMessage: string = '';

    handleApiError(err: any): void {
        this.formErrors = {};
        this.generalErrors = [];
        this.errorMessage = 'An unexpected error occurred.';

        if (err.error) {
            if (err.error.errors && Array.isArray(err.error.errors)) {
                for (const error of err.error.errors) {
                    const field = error.field?.trim();
                    const errorMsg = error.message;

                    if (field) {
                        if (!this.formErrors[field]) {
                            this.formErrors[field] = [];
                        }
                        this.formErrors[field].push(errorMsg);
                    } else {
                        this.generalErrors.push(errorMsg);
                    }
                }

                if (this.generalErrors.length) {
                    this.errorMessage = this.generalErrors.join('; ');
                }
            } else if (typeof err.error.error === 'string') {
                this.errorMessage = err.error.error;
                this.generalErrors.push(this.errorMessage);
            }
        }
        console.error('Error:', err);
    }
}
