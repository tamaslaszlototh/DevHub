# 🚀 DevHub: Personal Developer Productivity Cockpit

**DevHub** is a high-performance "Developer Cockpit" designed to eliminate tab-hopping and context-switching. Built with a modern **.NET 8+** and **Angular 17+** stack, it aggregates your professional life (GitHub, Slack, Calendar) into a single, real-time dashboard.

## ✨ Key Features
- **Unified Dashboard:** Real-time PR status, CI/CD build results, and upcoming meetings.
- **Focus Mode:** Integrated Pomodoro timer with automatic Slack "Do Not Disturb" (DND) sync.
- **Context Switching Log:** Automatically track time spent across different repositories.
- **Developer Analytics:** Insights into your most productive hours and meeting-to-coding ratios.
- **Multi-tenant Ready:** Architected as a SaaS-ready platform from day one.

## 🏗️ Tech Stack
**Backend**
- **.NET 8+ Web API** (Clean Architecture)
- **ASP.NET Core Identity** (Authentication & Authorization)
- **Entity Framework Core** with **PostgreSQL**
- **SignalR** for real-time UI updates
- **MediatR** (CQRS Pattern)
- **ErrorOr** for functional Result Pattern error handling
- **Hangfire** for background API synchronization

**Frontend**
- **Angular 17+** (Signals-based reactivity)
- **Tailwind CSS** for styling
- **Chart.js** for productivity analytics

## 🛣️ Roadmap
- [ ] GitHub PR Integration (Real-time)
- [ ] Slack DND Sync during Focus Mode
- [ ] VS Code Extension for activity tracking
- [ ] Exportable Weekly Productivity Reports