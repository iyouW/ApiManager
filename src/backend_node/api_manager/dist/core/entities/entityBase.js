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
exports.EntityBase = void 0;
const typeorm_1 = require("typeorm");
class EntityBase {
}
__decorate([
    typeorm_1.PrimaryColumn({
        name: 'id'
    }),
    __metadata("design:type", String)
], EntityBase.prototype, "id", void 0);
__decorate([
    typeorm_1.Column({
        name: 'is_deleted'
    }),
    __metadata("design:type", Boolean)
], EntityBase.prototype, "isDeleted", void 0);
__decorate([
    typeorm_1.Column({
        name: 'created_date'
    }),
    __metadata("design:type", Date)
], EntityBase.prototype, "createdDate", void 0);
__decorate([
    typeorm_1.Column({
        name: 'latest_updated_date'
    }),
    __metadata("design:type", Date)
], EntityBase.prototype, "latestUpdatedDate", void 0);
__decorate([
    typeorm_1.Column({
        name: 'created_account_id'
    }),
    __metadata("design:type", String)
], EntityBase.prototype, "createdAccountId", void 0);
__decorate([
    typeorm_1.Column({
        name: 'latest_updated_account_id'
    }),
    __metadata("design:type", String)
], EntityBase.prototype, "latestUpdatedAccountId", void 0);
exports.EntityBase = EntityBase;
//# sourceMappingURL=entityBase.js.map