# WebApp Template

A full-stack web application template featuring a .NET Core MVVM backend and React + Vite frontend, designed for seamless collaboration between backend and frontend developers.

## 🏗️ Architecture

### Backend (.NET Core MVVM)
- **Framework**: .NET 8.0 Web API
- **Pattern**: Model-View-ViewModel (MVVM)
- **Features**:
  - RESTful API endpoints
  - Dependency injection
  - CORS configuration
  - Swagger/OpenAPI documentation
  - In-memory data storage (easily replaceable with database)

### Frontend (React + Vite)
- **Framework**: React 18
- **Build Tool**: Vite
- **Styling**: Tailwind CSS
- **HTTP Client**: Axios
- **Features**:
  - Modern React hooks
  - Responsive design
  - API integration
  - Error handling
  - Loading states

## 📁 Project Structure

```
WebAppTemplate/
├── Backend/
│   └── WebAppTemplate.Api/
│       ├── Controllers/          # API controllers
│       ├── Models/              # Data models
│       ├── ViewModels/          # API request/response models
│       ├── Services/            # Business logic services
│       └── Program.cs           # Application configuration
└── Frontend/
    └── webapp-frontend/
        ├── src/
        │   ├── components/      # React components
        │   ├── services/        # API service layer
        │   ├── types/          # TypeScript types (if using TS)
        │   └── App.jsx         # Main application component
        ├── tailwind.config.js   # Tailwind configuration
        └── package.json        # Frontend dependencies
```

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- Node.js (v18 or higher)
- npm or yarn

### Backend Setup

1. Navigate to the backend directory:
   ```bash
   cd WebAppTemplate/Backend/WebAppTemplate.Api
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the API:
   ```bash
   dotnet run
   ```

The API will be available at:
- HTTPS: `https://localhost:7138`
- HTTP: `http://localhost:5138`
- Swagger UI: `https://localhost:7138` (root URL)

### Frontend Setup

1. Navigate to the frontend directory:
   ```bash
   cd WebAppTemplate/Frontend/webapp-frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm run dev
   ```

The frontend will be available at `http://localhost:5173`

## 🔌 API Endpoints

### Users
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create new user
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user (soft delete)

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/category/{category}` - Get products by category
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product (soft delete)

### Health Check
- `GET /api/health` - API health status

## 🤝 Collaboration Guidelines

### For Backend Developers
1. **API Contract First**: Define API endpoints and models before implementation
2. **Use ViewModels**: Separate internal models from API contracts
3. **Document Changes**: Update Swagger documentation for any API changes
4. **CORS Configuration**: Ensure frontend URLs are included in CORS policy
5. **Error Handling**: Return consistent error responses with proper HTTP status codes

### For Frontend Developers
1. **API Service Layer**: Use the provided API service (`src/services/api.js`)
2. **Error Handling**: Implement proper error states in components
3. **Loading States**: Show loading indicators during API calls
4. **Type Safety**: Use TypeScript types for API responses (if using TypeScript)
5. **Environment Variables**: Use environment variables for API URLs

### Communication Protocol
1. **API Changes**: Backend developers should notify frontend team of any breaking changes
2. **New Endpoints**: Document new endpoints in this README
3. **Data Models**: Share model changes and new fields
4. **Testing**: Both teams should test integration after changes

## 🛠️ Development Scripts

### Backend
```bash
# Run in development mode
dotnet run

# Run with hot reload
dotnet watch run

# Build for production
dotnet build --configuration Release

# Run tests (when added)
dotnet test
```

### Frontend
```bash
# Start development server
npm run dev

# Build for production
npm run build

# Preview production build
npm run preview

# Lint code
npm run lint
```

## 🎨 Customization

### Adding New Entities
1. **Backend**:
   - Create model in `Models/`
   - Create ViewModels in `ViewModels/`
   - Create service interface and implementation in `Services/`
   - Create controller in `Controllers/`
   - Register service in `Program.cs`

2. **Frontend**:
   - Add types to `types/api.js` (or `.ts`)
   - Add API methods to `services/api.js`
   - Create components in `components/`

### Database Integration
Replace the in-memory data in services with:
- Entity Framework Core
- Dapper
- Or any other data access technology

### Authentication
Add authentication by:
- Implementing JWT in the backend
- Adding authentication interceptors in the frontend
- Protecting routes and API endpoints

## 🔧 Configuration

### Backend Configuration
- `appsettings.json` - Application settings
- `appsettings.Development.json` - Development-specific settings
- `Program.cs` - Service registration and middleware configuration

### Frontend Configuration
- `vite.config.js` - Vite configuration
- `tailwind.config.js` - Tailwind CSS configuration
- `src/services/api.js` - API base URL and configuration

## 📝 Notes for Team Collaboration

1. **Version Control**: Use feature branches and pull requests
2. **API Versioning**: Consider API versioning for breaking changes
3. **Documentation**: Keep this README updated with changes
4. **Testing**: Add unit and integration tests as the project grows
5. **Deployment**: Set up CI/CD pipelines for automated deployment

## 🐛 Troubleshooting

### Common Issues

1. **CORS Errors**: 
   - Ensure frontend URL is in the CORS policy (`Program.cs`)
   - Check that the API is running on the expected port

2. **API Connection Failed**:
   - Verify backend is running on `https://localhost:7138`
   - Check if HTTPS certificate is trusted

3. **Build Errors**:
   - Ensure all dependencies are installed
   - Check .NET and Node.js versions

### Development Tips
- Use browser developer tools to inspect API calls
- Check console logs for detailed error messages
- Use Swagger UI for API testing and exploration
- Monitor network tab for API request/response details

## 📄 License

This template is provided as-is for educational and development purposes.