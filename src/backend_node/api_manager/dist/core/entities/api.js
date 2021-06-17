"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Api = void 0;
const typeorm_1 = require("typeorm");
const entityBase_1 = require("./entityBase");
class Api extends entityBase_1.EntityBase {
}
__decorate([
    typeorm_1.Column({
        name: 'name'
    }),
    __metadata("design:type", String)
], Api.prototype, "name", void 0);
__decorate([
    typeorm_1.Column({
        name: 'description'
    }),
    __metadata("design:type", String)
], Api.prototype, "description", void 0);
__decorate([
    typeorm_1.Column({
        name: 'is_supported'
    }),
    __metadata("design:type", Boolean)
], Api.prototype, "isSupported", void 0);
__decorate([
    typeorm_1.Column({
        name: 'is_parameter_standard'
    }),
    __metadata("design:type", Boolean)
], Api.prototype, "isParameterStandard", void 0);
__decorate([
    typeorm_1.Column({
        name: 'project_id'
    }),
    __metadata("design:type", String)
], Api.prototype, "projectId", void 0);
__decorate([
    typeorm_1.Column({
        name: 'module_id'
    }),
    __metadata("design:type", String)
], Api.prototype, "moduleId", void 0);
__decorate([
    typeorm_1.Column({
        name: 'proxy_id'
    }),
    __metadata("design:type", String)
], Api.prototype, "proxyId", void 0);
__decorate([
    typeorm_1.Column({
        name: 'author'
    }),
    __metadata("design:type", String)
], Api.prototype, "author", void 0);
__decorate([
    typeorm_1.Column({
        name: 'supported_app'
    }),
    __metadata("design:type", String)
], Api.prototype, "supportedApp", void 0);
__decorate([
    typeorm_1.Column({
        name: 'map_name'
    }),
    __metadata("design:type", String)
], Api.prototype, "mapName", void 0);
exports.Api = Api;
//# sourceMappingURL=api.js.map