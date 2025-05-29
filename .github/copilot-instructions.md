# GitHub Copilot Instructions

## General Guidelines
- Follow the existing coding style and conventions used in the project.
- Ensure all generated code is compatible with **.NET 9**.
- Use appropriate **namespaces** and **class names** that fit the project context.

## API Routes
- Follow the structure in `SystemApiRoutes.cs` when adding new API routes.
- Define route constants in the appropriate **nested static class**.
- Use appropriate HTTP methods (`[HttpGet]`, `[HttpPost]`, `[HttpPut]`, `[HttpDelete]`) for actions.

## Controllers
- Inject required services using **dependency injection** (e.g., `IUnitOfWork`).
- Use `[ProducesResponseType]` to specify expected response types and status codes.
- Ensure all controller actions return a proper **`IActionResult`**.
- Handle asynchronous operations with `async` and `await`.
- Include **detailed XML documentation** for endpoints in Arabic.

## DTOs (Data Transfer Objects)
- Use **data annotations** for validation (e.g., `[MaxLength]`, `[Range]`, `[Required]`).
- Follow naming conventions and structure similar to `ProjectDtos.cs`.
- Use `[JsonIgnore]` attributes to control JSON serialization behavior.

## Entity Framework Configuration
- Use `IEntityTypeConfiguration<T>` for entity configuration.
- Define **table names, property constraints, and relationships** in the `Configure` method.
- Apply **check constraints** and **query filters** to enforce business rules.

## Error Handling
- Configure `InvalidModelStateResponseFactory` to return `BaseResponse<object>` with detailed error messages.
- Return custom error responses using `BaseResponse<T>` for validation errors.
- Use appropriate HTTP status codes such as `BadRequest` and `NotFound`.

## Pagination and Filtering
- Implement pagination and filtering in `Get` methods using:
  - `pageNumber`
  - `pageSize`
  - `searchTerm`

## Repository Implementation
- Custom repositories should inherit from `BaseRepository<T>` to reuse common data access methods.
- Use **mapping profiles** (e.g., `ClientProfile`) for DTO-to-entity transformations.
- Utilize `ExpressionExtensions` for **dynamic LINQ filtering**.

## Example Task: Adding a New API Route
1. Define a new route constant in `SystemApiRoutes.Project`.
2. Add an action method in `ProjectsController` to handle the route.
3. Create a **DTO** if needed for the response.
4. Update **Swagger** documentation to include the new endpoint.

---

## Arabic Documentation Example

### Get All Clients
        /// <summary>
        /// الحصول على جميع العملاء
        /// </summary>
        /// <param name="pageNumber">رقم الصفحة</param>
        /// <param name="pageSize">حجم الصفحة</param>
        /// <param name="searchTerm">نص البحث, اختياري</param>
        /// <param name="clientType">نوع العميل, اختياري</param>
        /// <remarks>
        /// سيتم جلب العملاء الذين تحتوي اسماءهم او اي حقل من حقولهم عل النص البحثي في حالة ارفاقه ومن النوع المحدد
        /// <br/>
        /// في حالة لم يتم تحديد نص بحثي او نوع العميل سيم الجلب حسب الصفحات 
        /// <br/>
        /// ClientType Enum Values:
        /// <br/>
        /// 1 - individual (فرد)
        /// <br/>
        /// 2 - Company (شركة)       
        /// </remarks>
        /// <returns>قائمة العملاء</returns>


### Get Client By ID
        /// <summary>
        /// الحصول على عميل بواسطة المعرف
        /// </summary>
        /// <param name="Id">معرف العميل</param>
        /// <returns>تفاصيل العميل</returns>

### Add New Client
        /// <summary>
        /// إنشاء عميل جديد
        /// </summary>
        /// <param name="client">بيانات العميل</param>
        /// <remarks>
        /// ClientType Enum Values:
        /// 1 - individual (فرد)
        /// 2 - Company (شركة)
        /// </remarks>

### Update Worker
        /// <summary>
        /// تحديث عميل موجود
        /// </summary>
        /// <param name="client">بيانات العميل المحدثة</param>
        /// <returns>لا يوجد محتوى</returns>

### Delete Client
        /// <summary>
        /// حذف عميل
        /// </summary>
        /// <param name="id">معرف العميل</param>
        /// <returns>لا يوجد محتوى</returns>