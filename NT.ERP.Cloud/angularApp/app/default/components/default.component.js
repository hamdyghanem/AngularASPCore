var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { ProductService } from './../../core/services/product-data.service';
import { Product } from './../../models/product';
import { Component } from '@angular/core';
var DefaultComponent = (function () {
    function DefaultComponent(dataService) {
        this.dataService = dataService;
        this.products = [];
        this.product = new Product();
        this.message = 'ASP.NET Core API + Angular 4 Starter kit';
    }
    DefaultComponent.prototype.ngOnInit = function () {
        this.getAllThings();
    };
    DefaultComponent.prototype.addThing = function () {
        var _this = this;
        this.dataService
            .Add(this.product)
            .subscribe(function () {
            _this.getAllThings();
            _this.product = new Product();
        }, function (error) {
            console.log(error);
        });
    };
    DefaultComponent.prototype.deleteThing = function (product) {
        var _this = this;
        this.dataService
            .Delete(product.id)
            .subscribe(function () {
            _this.getAllThings();
        }, function (error) {
            console.log(error);
        });
    };
    DefaultComponent.prototype.getAllThings = function () {
        var _this = this;
        this.dataService
            .GetAll()
            .subscribe(function (data) { return _this.products = data; }, function (error) { return console.log(error); }, function () { return console.log('Get all complete'); });
    };
    return DefaultComponent;
}());
DefaultComponent = __decorate([
    Component({
        selector: 'default-component',
        templateUrl: 'default.component.html'
    }),
    __metadata("design:paramtypes", [ProductService])
], DefaultComponent);
export { DefaultComponent };
//# sourceMappingURL=default.component.js.map