import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule, MatLabel } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSidenavModule } from '@angular/material/sidenav';
import { NgxSpinnerModule } from 'ngx-spinner';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatLabel,
    MatFormFieldModule,
    MatIconModule,
    MatCardModule,
    MatGridListModule,
    MatTooltipModule,
    MatSidenavModule,
    NgxSpinnerModule,
    MatExpansionModule,
    MatListModule,
  ],
  exports: [
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatLabel,
    MatFormFieldModule,
    MatIconModule,
    MatCardModule,
    MatGridListModule,
    MatTooltipModule,
    MatSidenavModule,
    NgxSpinnerModule,
    MatExpansionModule,
    MatListModule,
  ],
})
export class MaterialModule {}
