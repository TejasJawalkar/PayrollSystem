import { Component, signal } from '@angular/core';
import { MaterialModule } from '../../../material.module';
import { OgranisationData } from '../../../core/modules/classes/OrganisationData';
import { CommonService } from '../../../core/services/CommonServices/common.service';
import { FormControl, FormGroup } from '@angular/forms';
import { LogService } from '../../../core/services/logServices/log.service';

@Component({
  selector: 'app-side-navbar',
  imports: [MaterialModule],
  templateUrl: './side-navbar.component.html',
  styleUrl: './side-navbar.component.scss',
})
export class SideNavbarComponent {
  readonly panelOpenState = signal(false);
  orgnisationData = new OgranisationData();

  loggroup!: FormGroup;
  router: any;

  constructor(
    private CommonServices: CommonService,
    private logservice: LogService
  ) {
    this.getOrganisationDetails();
  }
  getOrganisationDetails() {
    try {
      this.CommonServices.getOrgnisation().subscribe((result: any) => {
        if (result) {
          this.orgnisationData = result.Data;
        }
      });
    } catch (error) {
      this.loggroup.reset();
      this.loggroup = new FormGroup({
        ClassName: new FormControl(this.constructor.name),
        MethodName: new FormControl(this.getCurrentMethodName()),
        Exception: new FormControl(error),
        SiteName: new FormControl(this.router.url),
      });
      this.logservice.saveExceptionLog(this.loggroup.value);
    }
  }

  getCurrentMethodName(): string {
    return new Error().stack?.split('at ')[12].trim().split(' ')[0];
  }
}
