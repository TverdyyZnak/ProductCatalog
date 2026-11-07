import { Component, Inject, OnInit } from '@angular/core';
import { Product } from '../../models/Product';
import { ProductService } from '../../services/products/product.service';
import { CommonModule } from '@angular/common';
import { Filter } from '../../models/Filtre';
import { Category } from '../../models/Category';
import { CategoryService } from '../../services/categories/category.service';
import { FormsModule } from '@angular/forms';
import { JwtDecoderService } from '../../services/jwtService/jwt-decoder.service';
import { JwtModel } from '../../models/JwtModel';

export interface newProduct {
  name: '',
  description: '',
  price: 0,
  mainNote: '',
  subNote: '',
  categoryId: ''
}


@Component({
  selector: 'app-main-page',
  imports: [CommonModule, FormsModule],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent implements OnInit {

  private jwtDecoder = Inject(JwtDecoderService)

  constructor(private productService: ProductService, private categoryService: CategoryService, private jwtService: JwtDecoderService) { }

  products: Product[] | null = null
  categories: Category[] | null = null
  userJwt: JwtModel | null = null
  inCatalog: boolean = true

  createCategoryIsV: boolean = false
  productInfoIsV: boolean = false
  productUpdateIsV: boolean = false
  createProductIsV: boolean = false

  currentFiltre: Filter = {
    SearchName: '',
    MinPrice: undefined,
    MaxPrice: undefined,
    CategoryId: '',
    SortBy: ''
  }

  currentProduct: Product | null = null

  newProduct: newProduct = {
    name: '',
    description: '',
    price: 0,
    mainNote: '',
    subNote: '',
    categoryId: ''
  }


  ngOnInit() {
    this.loadProducts()
    this.loadCategories()
    this.userJwt = this.jwtService.getDecodedToken()
  }

  loadProducts() {
    this.productService.getProducts(this.currentFiltre).subscribe({
      next: (resp) => {
        this.products = resp
      }
    })
  }

  loadCategories() {
    this.categoryService.getAllCategories().subscribe({
      next: (resp) => {
        this.categories = resp
      }
    })
  }

  createCategory(name: string) {
    this.categoryService.createCategory(name).subscribe({
      next: (resp) => {
        this.createCategoryIsV = false
        this.loadCategories()
      }
    })
  }

  getCurrentProduct(id: string) {
    this.productInfoIsV = true
    this.currentProduct = this.products?.find(p => p.id === id) ?? null
  }

  getById(id: string) {
    this.currentProduct = this.products?.find(p => p.id === id) ?? null
  }

  updateProduct() {
    if (this.currentProduct != null) {
      this.productService.updateProduct(this.currentProduct.id, this.currentProduct).subscribe({
        next: (resp) => {
          this.productUpdateIsV = false
          this.productInfoIsV = false
        }
      })
    }
  }

  deleteProduct(id: string) {
    this.productService.deleteProduct(id).subscribe({
      next: (resp) => {

      }
    })
  }

  createProduct() {
    if (
      !this.newProduct.name.trim() ||
      !this.newProduct.categoryId ||
      this.newProduct.price <= 0
    ) {
      alert("Заполните название, категорию и корректную стоимость!");
      return;
    }

    this.productService.createProduct(this.newProduct).subscribe({
      next: () => {
        alert("Товар успешно создан!");

        this.createProductIsV = false;
        this.loadProducts();
      },
      error: (err) => {
        console.error(err);
        alert("Не удалось создать товар");
      }
    });
  }

}
