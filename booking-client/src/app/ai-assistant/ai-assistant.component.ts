import { Component } from '@angular/core';
import { AiAssistantService } from '../core/services/ai-assistant.service';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-ai-assistant',
  imports: [FormsModule, NgIf],
  templateUrl: './ai-assistant.component.html',
  styleUrl: './ai-assistant.component.css'
})
export class AiAssistantComponent {
  userMessage: string = '';
  aiReply: string = '';
  loading = false;



  constructor(private aiService: AiAssistantService) { }

  sendToAI() {

    this.loading = true;
    this.aiService.chatWithAI(this.userMessage).subscribe({
      next: (res) => {
        this.aiReply = res.reply;
        this.loading = false;
      },
      error: () => {
        this.aiReply = 'An error occurred. Please try again.';
        this.loading = false;
      }
    });
  }

  setExample(message: string): void {
    this.userMessage = message;
    this.sendToAI();
  }


}


