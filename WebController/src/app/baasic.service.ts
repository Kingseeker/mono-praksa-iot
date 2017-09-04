import { Injectable } from '@angular/core';
import { DynamicResourceService } from 'baasic-sdk-angular';
import { MembershipService } from 'baasic-sdk-angular';

@Injectable()
export class BaasicService {
    
    constructor(private dynamicResourceService: DynamicResourceService,
                private membershipService: MembershipService) { }

    sendData(schema, data){
        return this.dynamicResourceService.create(schema, data);
    }
    connect(data){
        return this.membershipService.login.login(data);
    }
}