// User types
export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  fullName: string;
  createdAt: string;
  isActive: boolean;
}

export interface CreateUserRequest {
  firstName: string;
  lastName: string;
  email: string;
}

export interface UpdateUserRequest {
  firstName: string;
  lastName: string;
  email: string;
  isActive: boolean;
}

// Product types
export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  formattedPrice: string;
  stockQuantity: number;
  category: string;
  createdAt: string;
  isActive: boolean;
  inStock: boolean;
}

export interface CreateProductRequest {
  name: string;
  description: string;
  price: number;
  stockQuantity: number;
  category: string;
}

export interface UpdateProductRequest {
  name: string;
  description: string;
  price: number;
  stockQuantity: number;
  category: string;
  isActive: boolean;
}

// API Response types
export interface ApiResponse<T> {
  data: T;
  success: boolean;
  message?: string;
}

export interface HealthCheck {
  status: string;
  timestamp: string;
}