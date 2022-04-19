export class Product {    
    Id: string = '';
    Name: string = '';
    Price: number = 0;
    Description: string = '';
    Promotion: ProductPromotion
}

export class ProductPromotion {

    Id: string;
    Description: string;
    Discount: number;
    MinimumQuantity: number;
}