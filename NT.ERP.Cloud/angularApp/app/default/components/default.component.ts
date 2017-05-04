import { ProductService } from './../../core/services/product-data.service';
import { Product } from './../../models/product';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'default-component',
    templateUrl: 'default.component.html'
})

export class DefaultComponent implements OnInit {

    public message: string;
    public products: Product[] = [];
    public product: Product = new Product();

    constructor(private dataService: ProductService) {
        this.message = 'ASP.NET Core API + Angular 4 Starter kit';
    }

    ngOnInit() {
        this.getAllThings();
    }

    public addThing() {
        this.dataService
            .Add(this.product)
            .subscribe(() => {
                this.getAllThings();
                this.product = new Product();
            }, (error) => {
                console.log(error);
            });
    }

    public deleteThing(product: Product) {
        this.dataService
            .Delete(product.id)
            .subscribe(() => {
                this.getAllThings();
            }, (error) => {
                console.log(error);
            });
    }

    private getAllThings() {
        this.dataService
            .GetAll()
            .subscribe(
            data => this.products = data,
            error => console.log(error),
            () => console.log('Get all complete')
            );
    }
}
