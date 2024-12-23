# BangaloreWalks API

BangaloreWalks API is a backend API designed to manage walks across various regions of Bangalore. It provides endpoints for user authentication, region management, walk management, and image uploads for walks.

---

## Technologies Used

- **ASP.NET Core**: The API is built using the ASP.NET Core framework, offering a powerful and flexible platform for developing web applications and APIs.
- **Entity Framework Core**: Used as the Object-Relational Mapping (ORM) tool to interact with the database.
- **Microsoft Identity**: Provides user authentication and role-based authorization.
- **AutoMapper**: Facilitates object-to-object mapping between domain models and DTOs.
- **Microsoft.AspNetCore.Mvc**: Handles HTTP requests and responses using ASP.NET Core's MVC framework.
- **Microsoft.Extensions.Logging**: Enables logging using the `ILogger` interface provided by ASP.NET Core.
- **IWebHostEnvironment**: Used to obtain web host environment information, such as the content root path.
- **IHttpContextAccessor**: Provides access to the `HttpContext`, used to retrieve the base URL for forming image file paths.

---

## API Endpoints

### **AuthController**

- **POST /api/Auth/Register**: Register a new user with a username, email, and password. Optionally, roles can be assigned during registration.
- **POST /api/Auth/Login**: Authenticate a user with email and password, returning a JWT token for further API access.

---

### **RegionController**

- **GET /api/Region**: Retrieve a list of all regions.
- **GET /api/Region/{id}**: Retrieve a specific region by its ID.
- **POST /api/Region**: Create a new region with the provided region data.
- **PUT /api/Region/{id}**: Update an existing region with the provided region data.
- **DELETE /api/Region/{id}**: Delete a region by its ID.

---

### **WalkController**

- **GET /api/Walk**: Retrieve a list of walks with optional filters and pagination.
- **GET /api/Walk/{id}**: Retrieve a specific walk by its ID.
- **POST /api/Walk**: Create a new walk with the provided walk data.
- **PUT /api/Walk/{id}**: Update an existing walk with the provided walk data.
- **DELETE /api/Walk/{id}**: Delete a walk by its ID.

---

### **ImageController**

- **POST /api/Image/Upload**: Upload an image file for a walk. The image is validated based on its extension and file signature.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contributing

Contributions are welcome! Please open an issue or submit a pull request to improve the API.

---

## Contact

For any queries or support, please contact [support@example.com](mailto:support@example.com).
