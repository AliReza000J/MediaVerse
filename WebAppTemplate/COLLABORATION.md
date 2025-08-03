# Collaboration Guide for Backend & Frontend Developers

This guide helps backend and frontend developers work together effectively on this template project.

## 🤝 Team Workflow

### Initial Setup (Both Teams)
1. Clone the repository
2. Run `./start-both.sh` to verify everything works
3. Check that both services are accessible:
   - Backend API: https://localhost:7138
   - Frontend: http://localhost:5173

## 👨‍💻 Backend Developer Guide

### Your Responsibilities
- Maintain the .NET Core Web API
- Define and implement data models
- Create and update API endpoints
- Ensure proper error handling and validation
- Keep API documentation current

### Key Files You'll Work With
```
Backend/WebAppTemplate.Api/
├── Controllers/          # Your API endpoints
├── Models/              # Your data models
├── ViewModels/          # API contracts (shared with frontend)
├── Services/            # Your business logic
└── Program.cs           # Configuration and startup
```

### Development Workflow
1. **Start your API**: `./start-backend.sh`
2. **Make changes** to controllers, models, or services
3. **Test endpoints** using Swagger UI at https://localhost:7138
4. **Notify frontend team** of any API changes
5. **Update documentation** when adding new endpoints

### API Design Best Practices
```csharp
// ✅ Good: Use ViewModels for API contracts
public class UserViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    // ... other properties
}

// ✅ Good: Consistent error responses
[HttpGet("{id}")]
public async Task<ActionResult<UserViewModel>> GetUser(int id)
{
    var user = await _userService.GetUserByIdAsync(id);
    if (user == null)
    {
        return NotFound($"User with ID {id} not found");
    }
    return Ok(user);
}
```

### Adding New Endpoints
1. Create/update model in `Models/`
2. Create ViewModels in `ViewModels/`
3. Create service interface and implementation in `Services/`
4. Create controller in `Controllers/`
5. Register service in `Program.cs`
6. Update this documentation

### Communication Checklist
- [ ] New endpoint added? → Notify frontend team
- [ ] Model changed? → Share updated ViewModels
- [ ] Breaking change? → Coordinate with frontend team
- [ ] Error responses changed? → Update frontend error handling

## 🎨 Frontend Developer Guide

### Your Responsibilities
- Maintain the React frontend application
- Implement user interfaces and interactions
- Handle API integration and error states
- Ensure responsive design and good UX

### Key Files You'll Work With
```
Frontend/webapp-frontend/src/
├── components/          # Your React components
├── services/            # API integration layer
├── types/              # Type definitions (if using TypeScript)
└── App.jsx             # Main application
```

### Development Workflow
1. **Start your frontend**: `./start-frontend.sh`
2. **Make changes** to components and styles
3. **Test API integration** with the backend
4. **Handle loading and error states**
5. **Ensure responsive design**

### API Integration Best Practices
```javascript
// ✅ Good: Use the API service layer
import { userApi } from '../services/api';

// ✅ Good: Handle loading and error states
const [users, setUsers] = useState([]);
const [loading, setLoading] = useState(true);
const [error, setError] = useState(null);

useEffect(() => {
  const fetchUsers = async () => {
    try {
      setLoading(true);
      const userData = await userApi.getAll();
      setUsers(userData);
      setError(null);
    } catch (err) {
      setError('Failed to fetch users');
    } finally {
      setLoading(false);
    }
  };
  fetchUsers();
}, []);
```

### Adding New Features
1. Check if API endpoints exist (ask backend team if not)
2. Add API methods to `services/api.js`
3. Create components in `components/`
4. Add proper error handling and loading states
5. Test with real API data

### Communication Checklist
- [ ] Need new endpoint? → Request from backend team
- [ ] API response changed? → Update component logic
- [ ] Error handling needed? → Coordinate error response format
- [ ] New feature? → Ensure API contract is defined

## 🔄 Integration Workflow

### When Backend Makes Changes
1. **Backend developer** makes API changes
2. **Backend developer** updates Swagger documentation
3. **Backend developer** notifies frontend team with:
   - What changed (endpoints, models, responses)
   - Breaking changes (if any)
   - New endpoints available
4. **Frontend developer** updates API service and components
5. **Both teams** test integration

### When Frontend Needs New Features
1. **Frontend developer** identifies need for new API functionality
2. **Frontend developer** creates feature request with:
   - What data is needed
   - What operations are required
   - Expected response format
3. **Backend developer** implements API endpoints
4. **Backend developer** updates documentation
5. **Frontend developer** integrates new endpoints
6. **Both teams** test integration

## 🚨 Common Issues & Solutions

### CORS Errors
**Problem**: Frontend can't access backend API
**Solution**: Backend developer adds frontend URL to CORS policy in `Program.cs`

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Add your frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```

### API Not Found (404)
**Problem**: Frontend gets 404 when calling API
**Solution**: 
- Backend: Ensure controller route is correct
- Frontend: Verify API URL in `services/api.js`

### Data Format Mismatch
**Problem**: Frontend expects different data structure
**Solution**: 
- Use ViewModels in backend to control API response format
- Update frontend components to match actual API response

## 📋 Testing Checklist

Before merging any changes:

### Backend Developer
- [ ] All endpoints return expected data format
- [ ] Error responses are consistent
- [ ] Swagger documentation is updated
- [ ] CORS is configured for frontend URL
- [ ] API can be accessed from browser

### Frontend Developer
- [ ] All API calls handle errors gracefully
- [ ] Loading states are implemented
- [ ] Components work with real API data
- [ ] No console errors in browser
- [ ] Responsive design works on different screen sizes

### Both Teams
- [ ] Full user flow works end-to-end
- [ ] Error scenarios are handled properly
- [ ] Performance is acceptable
- [ ] Documentation is updated

## 🛠️ Quick Commands

```bash
# Start both services
./start-both.sh

# Start only backend
./start-backend.sh

# Start only frontend
./start-frontend.sh

# Test API health
curl https://localhost:7138/health

# View API documentation
# Open https://localhost:7138 in browser
```

## 📞 Communication Templates

### Backend to Frontend: API Change Notification
```
🔄 API Update Notification

Endpoint: POST /api/users
Changes: 
- Added required field: phoneNumber
- Response now includes: createdAt timestamp

Breaking: Yes - phoneNumber is now required
Migration: Update CreateUserRequest to include phoneNumber

Swagger: https://localhost:7138
```

### Frontend to Backend: Feature Request
```
🚀 New Feature Request

Feature: User Profile Management
Endpoints needed:
- GET /api/users/{id}/profile
- PUT /api/users/{id}/profile

Expected data:
- User basic info
- Profile picture URL
- Bio/description
- Social links

Priority: Medium
Timeline: Next sprint
```

Remember: Good communication prevents integration issues! 🤝