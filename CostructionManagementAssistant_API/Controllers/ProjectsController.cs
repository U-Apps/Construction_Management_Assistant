using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_Core.Extentions;

namespace ConstructionManagementAssistant_API.Controllers;

[ApiController]
public class ProjectsController(IUnitOfWork _unitOfWork) : ControllerBase
{
    #region Get All Projects

    /// <summary>
    /// الحصول على جميع المشاريع
    /// </summary>
    /// <param name="pageSize">حجم الصفحة</param>
    /// <param name="pageNumber">رقم الصفحة</param>
    /// <summary>
    /// حالة المشروع
    /// </summary>
    /// <param name="status">حالة المشروع اختياري (0=لم يبدأ , 1=قيد التنفيذ , 2=معلق 3=مكتمل 4=ملغي )</param>
    /// <param name="searchTerm">مصطلح البحث اختياري</param>
    /// <returns>قائمة المشاريع</returns>
    /// <response code="200">تم العثور على المشاريع</response>
    [HttpGet(SystemApiRouts.Project.GetAllProjects)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<object>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProjects(int pageNumber = 1,
        [Range(1, 50)] int pageSize = 10, 
        ProjectStatus? status = null, string?searchTerm = null)
    {
        var result = await _unitOfWork.Projects.GetAllProjects(pageNumber, pageSize,status, searchTerm);
        if (result.Items == null || result.Items.Count == 0)
        {
            return NotFound(new BaseResponse<PagedResult<GetProjectsDto>>
            {
                Success = false,
                Message = "لم يتم العثور على المشاريع",
            });
        }

        return Ok(new BaseResponse<PagedResult<GetProjectsDto>>
        {
            Success = true,
            Message = "تم جلب المشاريع بنجاح",
            Data = result,
        });
    }


    #endregion

    #region Get Project By Id

    /// <summary>
    /// الحصول على مشروع بواسطة المعرف
    /// </summary>
    /// <param name="id">معرف المشروع</param>
    /// <returns>تفاصيل المشروع</returns>
    /// <response code="200">تم العثور على المشروع</response>
    /// <response code="404">لم يتم العثور على المشروع</response>
    [HttpGet(SystemApiRouts.Project.GetProjectById)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await _unitOfWork.Projects.GetProjectById(id);
        if (project == null)
        {
            return NotFound(new BaseResponse<GetProjectsDto>
            {
                Success = false,
                Message = "لم يتم العثور على المشروع",
            });
        }

        return Ok(new BaseResponse<GetProjectsDto>
        {
            Success = true,
            Message = "تم العثور على المشروع",
            Data = project,
        });
    }

    #endregion

    #region Add Project

    /// <summary>
    /// إضافة مشروع جديد
    /// </summary>
    /// <param name="project">تفاصيل المشروع الجديد</param>
    /// <returns>المشروع المضاف</returns>
    /// <response code="200">تم إضافة المشروع بنجاح</response>
    /// <response code="400">بيانات المشروع غير صحيحة</response>
    [HttpPost(SystemApiRouts.Project.AddProject)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddProject([FromBody] AddProjectDto project)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new BaseResponse<string>
            {
                Success = false,
                Message = "بيانات المشروع غير صحيحة",
            });
        }

        var response = await _unitOfWork.Projects.AddProjectAsync(project);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(new BaseResponse<string>
        {
            Success = true,
            Message = "تم إضافة المشروع بنجاح",
            Data = response.Data,
        });
    }

    #endregion

    #region Update Project

    /// <summary>
    /// تحديث مشروع موجود
    /// </summary>
    /// <param name="project">تفاصيل المشروع المحدث</param>
    /// <returns>المشروع المحدث</returns>
    /// <response code="200">تم تحديث المشروع بنجاح</response>
    /// <response code="400">بيانات المشروع غير صحيحة</response>
    /// <response code="404">لم يتم العثور على المشروع</response>
    [HttpPut(SystemApiRouts.Project.UpdateProject)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDto project)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new BaseResponse<string>
            {
                Success = false,
                Message = "بيانات المشروع غير صحيحة",
            });
        }

        var response = await _unitOfWork.Projects.UpdateProjectAsync(project);
        if (!response.Success)
        {
            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم العثور على المشروع",
            });
        }

        return Ok(new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المشروع بنجاح",
            Data = response.Data,
        });
    }

    #endregion

    #region Delete Project

    /// <summary>
    /// حذف مشروع بواسطة المعرف
    /// </summary>
    /// <param name="id">معرف المشروع</param>
    /// <returns>نتيجة الحذف</returns>
    /// <response code="200">تم حذف المشروع بنجاح</response>
    /// <response code="404">لم يتم العثور على المشروع</response>
    [HttpDelete(SystemApiRouts.Project.DeleteProject)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var response = await _unitOfWork.Projects.DeleteProjectAsync(id);
        if (!response.Success)
        {
            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم العثور على المشروع",
            });
        }

        return Ok(new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف المشروع بنجاح",
            Data = response.Data,
        });
    }

    #endregion

    #region Complete Project

    /// <summary>
    /// إكمال مشروع
    /// </summary>
    /// <param name="id">معرف المشروع</param>
    /// <returns>نتيجة الإكمال</returns>
    /// <response code="200">تم إكمال المشروع بنجاح</response>
    /// <response code="404">لم يتم العثور على المشروع</response>
    [HttpPost(SystemApiRouts.Project.CompleteProject)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CompleteProject(int id)
    {
        var project = await _unitOfWork.Projects.GetProjectById(id);
        if (project == null)
        {
            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم العثور على المشروع",
            });
        }

        var updatedProject = new UpdateProjectDto
        {
            Id = project.Id,
            ProjectName = project.ProjectName,
            SiteAddress = project.SiteAddress,
            ProjectStatus = ProjectStatus.Completed.GetDisplayName()
        };

        var response = await _unitOfWork.Projects.UpdateProjectAsync(updatedProject);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(new BaseResponse<string>
        {
            Success = true,
            Message = "تم إكمال المشروع بنجاح",
            Data = response.Data,
        });
    }

    #endregion

    #region Cancel Project

    /// <summary>
    /// إلغاء مشروع
    /// </summary>
    /// <param name="id">معرف المشروع</param>
    /// <returns>نتيجة الإلغاء</returns>
    /// <response code="200">تم إلغاء المشروع بنجاح</response>
    /// <response code="404">لم يتم العثور على المشروع</response>
    [HttpPost(SystemApiRouts.Project.CancelProject)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelProject(int id)
    {
        var project = await _unitOfWork.Projects.GetProjectById(id);
        if (project == null)
        {
            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم العثور على المشروع",
            });
        }

        var updatedProject = new UpdateProjectDto
        {
            Id = project.Id,
            ProjectName = project.ProjectName,
            SiteAddress = project.SiteAddress,
            ProjectStatus = ProjectStatus.Cancelled.GetDisplayName()
        };

        var response = await _unitOfWork.Projects.UpdateProjectAsync(updatedProject);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(new BaseResponse<string>
        {
            Success = true,
            Message = "تم إلغاء المشروع بنجاح",
            Data = response.Data,
        });
    }
    #endregion

    #region Assign Project To Site Engineer

    /// <summary>
    /// تعيين مشروع لمهندس الموقع
    /// </summary>
    /// <param name="projectId">معرف المشروع</param>
    /// <param name="siteEngineerId">معرف مهندس الموقع</param>
    /// <returns>نتيجة التعيين</returns>
    /// <response code="200">تم تعيين المشروع بنجاح</response>
    /// <response code="404">لم يتم العثور على المشروع أو مهندس الموقع</response>
    [HttpPost(SystemApiRouts.Project.AssignProjectToSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssignProjectToSiteEngineer(int projectId, int siteEngineerId)
    {
        var project = await _unitOfWork.Projects.GetProjectById(projectId);
        if (project == null)
        {
            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم العثور على المشروع",
            });
        }

        var siteEngineer = await _unitOfWork.SiteEngineers.GetSiteEngineerById(siteEngineerId);
        if (siteEngineer == null)
        {
            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم العثور على مهندس الموقع",
            });
        }

        var updatedProject = new UpdateProjectDto
        {
            Id = project.Id,
            ProjectName = project.ProjectName,
            SiteAddress = project.SiteAddress,
            SiteEngineerId = siteEngineerId
        };

        var response = await _unitOfWork.Projects.UpdateProjectAsync(updatedProject);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(new BaseResponse<string>
        {
            Success = true,
            Message = "تم تعيين المشروع بنجاح",
            Data = response.Data,
        });
    }

    #endregion
}

