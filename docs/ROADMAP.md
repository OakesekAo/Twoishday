# Project Modernization Roadmap

> **Current Status**: Phase 1 - UI Cleanup & Responsive Design  
> **Branch**: `feature/modernization-2024`  
> **Target Completion**: TBD  

---

## 📋 Overview

This roadmap outlines the complete modernization plan for transforming the current bug tracker application into a modern, feature-rich project management platform comparable to Azure DevOps Boards.

### Goals
1. Clean, consistent, responsive UI across all views
2. Feature parity with Azure DevOps basic board/ticket functionality
3. Rebrand with intuitive naming
4. Modern Blazor frontend as optional UI layer

---

## Phase 1: UI Cleanup & Responsive Design
**Priority**: 🔴 HIGH  
**Status**: 🟡 In Progress

### 1.1 Layout & Navigation ✅ COMPLETE
- [x] Audit `_Layout.cshtml` for responsive breakpoints
- [x] Fix sidebar collapse behavior on mobile
- [x] Add hamburger menu for mobile navigation
- [x] Ensure consistent header/footer across all pages
- [x] Review and fix any hardcoded widths/heights
- [x] Add breadcrumb navigation

**Completion Date:** 2024  
**Documentation:** See `docs/PHASE1-1-LAYOUT-NOTES.md`

### 1.2 Landing Page Overhaul (`Views/Home/Index.cshtml`) ✅ COMPLETE
- [x] Fix HTML typo: `<pclass` → `<p class` ✅
- [x] Redesign hero section with clear value proposition ✅
- [x] Add animated illustrations or modern graphics ✅
- [x] Create "How it Works" section with steps ✅
- [x] Add social proof section (testimonials/logos) ✅
- [x] Design proper CTA buttons (Sign Up, Try Demo, Learn More) ✅
- [x] Add footer with links, contact info, social media ✅ (Removed - in layout)
- [x] Implement smooth scroll and animations ✅
- [x] Add logged-in user redirect to dashboard ✅
- [x] Ensure mobile-first responsive design ✅

**Completion Date:** January 2025  
**Key Features:**
- Modern gradient hero section with compelling value proposition
- Clear CTAs (Get Started Free, Try Demo, Contact Sales)
- "How It Works" 3-step process with animated cards
- Enhanced feature cards with Bootstrap Icons
- Professional testimonial cards with user avatars
- Social proof with company logos section
- Contact section with info (Email: hello@twoishday.com)
- Smooth scroll animations using Intersection Observer API
- Fully responsive design following mobile-first approach (60px mobile, 100px desktop padding)
- Logged-in users automatically redirected to dashboard (no sidebar on landing page)
- Separate CSS file (`landing.css`) for better maintainability
- Follows all coding patterns from CODING-PATTERNS.md

**Technical Notes:**
- CSS moved to `wwwroot/css/landing.css` to avoid Razor parsing issues with `@media` queries
- Mobile-first breakpoints at 768px for tablet/desktop
- Reduced motion support for accessibility
- Standard transitions (0.3s ease-in-out)

### 1.3 Dashboard Improvements (`Views/Home/Dashboard.cshtml`)
- [ ] Uncomment and implement chart sections
- [ ] Add KPI cards (total projects, tickets, open/closed, overdue)
- [ ] Add ticket velocity/burndown chart
- [ ] Add tickets by status pie chart
- [ ] Add tickets by priority bar chart
- [ ] Add recent activity feed
- [ ] Add "My Assigned Tickets" quick view
- [ ] Add project health indicators
- [ ] Make dashboard cards responsive (stack on mobile)

### 1.4 Projects Views
- [ ] `AllProjects.cshtml` - Add card/grid view option, improve table
- [ ] `MyProjects.cshtml` - Add progress indicators
- [ ] `Details.cshtml` - Redesign project overview, add tabs
- [ ] `Create.cshtml` - Improve form layout, add validation feedback
- [ ] `Edit.cshtml` - Match Create styling
- [ ] `AssignMembers.cshtml` - Better member selection UI
- [ ] `AssignPM.cshtml` - Improve dropdown/search
- [ ] `ArchivedProjects.cshtml` - Add restore bulk actions

### 1.5 Tickets Views
- [ ] `AllTickets.cshtml` - Add filtering, sorting, search
- [ ] `MyTickets.cshtml` - Add status grouping
- [ ] `Details.cshtml` - Redesign with sidebar, activity timeline
- [ ] `Create.cshtml` - Multi-step or sectioned form
- [ ] `Edit.cshtml` - Match Create styling
- [ ] `AssignDeveloper.cshtml` - Better user picker
- [ ] `UnassignedTickets.cshtml` - Add bulk assignment
- [ ] `ArchivedTickets.cshtml` - Add restore options

### 1.6 Other Views
- [ ] `Companies/Index.cshtml` - Clean company management
- [ ] `Notifications/Index.cshtml` - Better notification list
- [ ] `UserRoles/ManageUserRoles.cshtml` - Improved role management
- [ ] `Invites/*` - Streamline invitation flow

### 1.7 Shared Components
- [ ] Create reusable `_StatusBadge.cshtml` partial
- [ ] Create reusable `_PriorityBadge.cshtml` partial
- [ ] Create reusable `_UserAvatar.cshtml` partial
- [ ] Create reusable `_Pagination.cshtml` partial
- [ ] Create reusable `_EmptyState.cshtml` partial
- [ ] Standardize table styling across views
- [ ] Standardize form styling across views
- [ ] Standardize card styling across views

---

## Phase 2: Rebrand
**Priority**: 🟠 MEDIUM  
**Status**: ⚪ Not Started

### 2.1 Name Selection
- [ ] Brainstorm new names (suggestions below)
- [ ] Check domain availability
- [ ] Check trademark availability
- [ ] Final name decision

**Name Ideas** (to be discussed):
- **TaskFlow** - Clear, describes the flow of tasks
- **BoardStack** - References boards, stacking priorities
- **SprintBoard** - Agile terminology
- **DevTrack** - Developer tracking
- **IssueHub** - Central hub for issues
- **FlowBoard** - Visual flow of work
- **WorkStream** - Stream of work items

### 2.2 Branding Assets
- [ ] Design new logo
- [ ] Define color palette
- [ ] Define typography
- [ ] Create favicon
- [ ] Update all references to "Twoishday"
- [ ] Update email templates
- [ ] Update meta tags and SEO

### 2.3 Code Refactoring for Rebrand
- [ ] Rename `TDUser` → `AppUser` or new prefix
- [ ] Rename `TD*Service` → New prefix
- [ ] Rename `ITD*Service` → New prefix
- [ ] Update namespaces
- [ ] Update database seed data

---

## Phase 3: Azure DevOps Feature Parity
**Priority**: 🟠 MEDIUM  
**Status**: ⚪ Not Started

### 3.1 Board View (Kanban)
- [ ] Create `BoardController` with board actions
- [ ] Create `Board.cshtml` view with swim lanes
- [ ] Implement drag-and-drop ticket movement
- [ ] Add Work In Progress (WIP) limits
- [ ] Add column configuration (custom statuses)
- [ ] Add filtering by assignee, priority, type

### 3.2 Sprint/Iteration Support
- [ ] Create `Sprint` model (Name, StartDate, EndDate, ProjectId)
- [ ] Create `SprintsController`
- [ ] Add sprint assignment to tickets
- [ ] Create Sprint Planning view
- [ ] Create Sprint Board view
- [ ] Add burndown chart per sprint
- [ ] Add velocity tracking

### 3.3 Backlog Management
- [ ] Create `Backlog.cshtml` view
- [ ] Add drag-and-drop reordering
- [ ] Add bulk edit operations
- [ ] Add parent/child ticket relationships (Epics → Stories → Tasks)
- [ ] Add story points/estimation field to Ticket model

### 3.4 Work Item Types Expansion
- [ ] Add "Epic" ticket type
- [ ] Add "User Story" ticket type  
- [ ] Add "Task" ticket type
- [ ] Add "Bug" ticket type (existing)
- [ ] Add "Feature" ticket type
- [ ] Add parent-child relationships
- [ ] Add related links between tickets

### 3.5 Advanced Ticket Features
- [ ] Add custom fields support
- [ ] Add tags/labels
- [ ] Add @mentions in comments
- [ ] Add ticket templates
- [ ] Add time tracking (Original Estimate, Remaining, Completed)
- [ ] Add acceptance criteria field
- [ ] Add reproduction steps field (for bugs)

### 3.6 Queries & Filters
- [ ] Create saved queries feature
- [ ] Add advanced filter builder
- [ ] Add query results export (CSV, Excel)
- [ ] Add shared team queries

### 3.7 Notifications & Alerts
- [ ] Real-time notifications with SignalR
- [ ] @mention notifications
- [ ] Subscription to ticket updates
- [ ] Email digest options (daily, weekly)
- [ ] Browser push notifications

### 3.8 Wiki/Documentation
- [ ] Add Wiki model and controller
- [ ] Markdown editor for wiki pages
- [ ] Version history for wiki pages
- [ ] Link wiki to projects

---

## Phase 4: Backend Improvements
**Priority**: 🟠 MEDIUM  
**Status**: ⚪ Not Started

### 4.1 API Layer
- [ ] Create `Api/` folder for API controllers
- [ ] Create `ProjectsApiController` with REST endpoints
- [ ] Create `TicketsApiController` with REST endpoints
- [ ] Create `BoardApiController` for board operations
- [ ] Create `UsersApiController`
- [ ] Add API versioning
- [ ] Add Swagger/OpenAPI documentation
- [ ] Add JWT authentication for API

### 4.2 Service Layer Cleanup
- [ ] Refactor `InvitesController` to use `ITDInviteService`
- [ ] Add missing service methods for new features
- [ ] Add caching for frequently accessed data
- [ ] Add pagination to all list methods

### 4.3 Performance
- [ ] Add response caching
- [ ] Optimize database queries (review N+1 issues)
- [ ] Add database indexes where needed
- [ ] Implement lazy loading properly

### 4.4 Testing
- [ ] Set up xUnit test project
- [ ] Add unit tests for services
- [ ] Add integration tests for controllers
- [ ] Add UI tests with Playwright

---

## Phase 5: Blazor Frontend
**Priority**: 🟢 LOW (after backend ready)  
**Status**: ⚪ Not Started

### 5.1 Setup
- [ ] Decide: Blazor Server vs WebAssembly vs Hybrid
- [ ] Create `Twoishday.Client` Blazor project
- [ ] Set up shared models library
- [ ] Configure API communication

### 5.2 Blazor Components
- [ ] Create `MainLayout.razor`
- [ ] Create `NavMenu.razor`
- [ ] Create `Dashboard.razor`
- [ ] Create `ProjectList.razor`
- [ ] Create `ProjectDetails.razor`
- [ ] Create `TicketList.razor`
- [ ] Create `TicketDetails.razor`
- [ ] Create `KanbanBoard.razor` with drag-drop
- [ ] Create `SprintBoard.razor`

### 5.3 Shared Components
- [ ] Create `StatusBadge.razor`
- [ ] Create `PriorityBadge.razor`
- [ ] Create `UserAvatar.razor`
- [ ] Create `DataTable.razor` (sortable, filterable)
- [ ] Create `Modal.razor`
- [ ] Create `Toast.razor` notifications
- [ ] Create `ConfirmDialog.razor`

### 5.4 State Management
- [ ] Choose state management (Fluxor, built-in, etc.)
- [ ] Implement authentication state
- [ ] Implement project/ticket state

---

## Phase 6: .NET Upgrade
**Priority**: 🟢 LOW (do last for stability)  
**Status**: ✅ **COMPLETE**

### 6.1 Preparation
- [x] Review breaking changes for .NET 8/9/10
- [x] Update all NuGet packages
- [x] Run .NET Upgrade Assistant (manual upgrade performed)
- [ ] Update `Startup.cs` to minimal hosting (optional - deferred)

### 6.2 Execution
- [x] Update `TargetFramework` in `.csproj` from net6.0 to net10.0
- [x] Fix any breaking changes (4 warnings fixed, 0 errors)
- [ ] Update Docker/deployment configs if applicable (N/A)
- [x] Test all functionality (all tests passed)

**Completion Date**: January 2025  
**Duration**: ~3 hours  
**Branch**: `upgrade-to-NET10`  
**Status**: ✅ All tests passed, application running on .NET 10.0 (LTS)

**Key Achievements**:
- ✅ Upgraded from .NET 6.0 to .NET 10.0 (LTS - supported until 2028)
- ✅ Updated all packages to .NET 10 compatible versions
- ✅ Clean build achieved: 0 errors, 0 warnings
- ✅ Npgsql 10.0 timestamp compatibility verified
- ✅ All CRUD operations tested and working
- ✅ User Secrets configured for secure local development

**Documentation**: See `.github/upgrades/scenarios/new-dotnet-version_e9cbd2/COMPLETION_SUMMARY.md`

---

## Phase 7: Miscellaneous Improvements
**Priority**: 🟡 VARIES  
**Status**: ⚪ Not Started

> This phase captures features, bugs, and improvements discovered during development that don't fit into the main modernization phases.

### 7.1 Layout Improvements
- [ ] Create separate layout for non-authenticated users (`_PublicLayout.cshtml`)
  - Keep everything in top navbar (logo, login, register links)
  - Remove sidebar for public pages (landing page, etc.)
  - Cleaner, simpler design for marketing pages
  - Current: Landing page uses authenticated layout with sidebar (jarring experience)
  - Goal: Professional public-facing layout without application chrome

### 7.2 Authentication & User Experience
- [ ] TBD - Items to be added as discovered

### 7.3 Bug Fixes
- [ ] TBD - Items to be added as discovered

### 7.4 Performance Optimizations
- [ ] TBD - Items to be added as discovered

### 7.5 Accessibility Improvements
- [ ] TBD - Items to be added as discovered

---

## 📊 Progress Tracker

| Phase | Status | Progress |
|-------|--------|----------|
| Phase 1: UI Cleanup | 🟡 In Progress | 25% |
| Phase 2: Rebrand | ⚪ Not Started | 0% |
| Phase 3: Azure DevOps Features | ⚪ Not Started | 0% |
| Phase 4: Backend Improvements | ⚪ Not Started | 0% |
| Phase 5: Blazor Frontend | ⚪ Not Started | 0% |
| Phase 6: .NET Upgrade | ✅ **COMPLETE** | **100%** |
| Phase 7: Miscellaneous | ⚪ Not Started | 0% |

---

## 🗓️ Timeline (Estimated)

| Phase | Duration | Target | Actual |
|-------|----------|--------|--------|
| Phase 1 | 2-3 weeks | TBD | In Progress |
| Phase 2 | 1 week | TBD | - |
| Phase 3 | 4-6 weeks | TBD | - |
| Phase 4 | 2-3 weeks | TBD | - |
| Phase 5 | 4-6 weeks | TBD | - |
| Phase 6 | 1-2 days | TBD | ✅ 3 hours (Jan 2025) |

---

## 📝 Notes

### Dependencies Between Phases
- Phase 2 (Rebrand) can run parallel to Phase 1
- Phase 4 (API Layer) must be complete before Phase 5 (Blazor)
- Phase 6 (.NET Upgrade) should be done after all features are stable

### Resources Needed
- UI/UX designer (optional, for rebrand)
- Chart library: Chart.js or ApexCharts
- Drag-drop library: SortableJS or native HTML5
- SignalR for real-time features

---

## 🐛 Known Issues to Fix

1. ~~`Views/Home/Index.cshtml` line 27: `<pclass` should be `<p class`~~ ✅ FIXED
2. Dashboard charts are commented out and not implemented
3. `InvitesController` uses direct DbContext instead of service layer
4. Some views may have hardcoded styles instead of Bootstrap classes
5. Missing mobile responsiveness in several views → **Phase 1.1 addressed layout-level responsiveness** ✅

---

*Last Updated: January 2025*  
*Branch: feature/modernization-2024*  
*Phase 1.1 Complete: ✅*  
*Phase 1.2 Complete: ✅ (Landing Page Overhaul - Jan 2025)*  
*Phase 6 Complete: ✅ (.NET 10 Upgrade - Jan 2025)*
