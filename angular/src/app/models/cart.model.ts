import * as uuid from 'uuid';

export class Cart {

    constructor() {
        this.id = uuid.v4();
        this.total = 0;
        this.items = [];
    }

    id: string;
    total: number = 0;
    items: CartItems[] = [];
}

export class CartItems {

    constructor(productId: string, quantity: number) {
        this.productId = productId;
        this.name = '';
        this.price = 0;
        this.discount = 0;
        this.total = 0;
        this.quantity = quantity;
    }

    id: string;
    productId: string;
    name: string;
    quantity: number;
    price: number;
    discount: number;
    total: number;
    promotion: string
}