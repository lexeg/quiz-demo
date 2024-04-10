import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'main-component',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './main-component.html',
  styleUrl: './main-component.css',
})
export class MainComponent {}
