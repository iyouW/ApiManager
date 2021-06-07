CREATE TABLE `api` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL COMMENT '标识',
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '名称',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '描述',
  `is_supported` TINYINT(4) COMMENT '是否支持',
  `is_parameter_standard` TINYINT(4) COMMENT '入参是否标准格式',
  `map_name` VARCHAR(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '映射名称',
  `project_id` VARCHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '',
  `module_id` VARCHAR (36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT  NULL COMMENT '',
  `proxy_id` VARCHAR (36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT  NULL COMMENT '',
  `supported_app` VARCHAR (128) COMMENT '支持的app以及版本',
  `author` VARCHAR (128) COMMENT '作者',
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT  '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT  '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

CREATE TABLE `app` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL COMMENT '标识',
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '名称',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '描述',
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;



CREATE TABLE `module` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL COMMENT '标识',
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '名称',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '描述',
  `project_id` VARCHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '',
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

CREATE TABLE `parameter` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL COMMENT '标识',
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '名称',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '描述',
  `comment` VARCHAR(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '注释',
  `type` TINYINT(8) COMMENT '',
  `category` TINYINT (8) COMMENT '',
  `api_id` VARCHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '',
  `parent_id` VARCHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '',
  `mock` TEXT COMMENT '模拟数据',
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

CREATE TABLE `project` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL,
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

CREATE TABLE `proxy` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL COMMENT '标识',
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '名称',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '描述',
  `project_id` VARCHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '',
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;


CREATE TABLE `version` (
  `id` varchar(36) COLLATE utf8mb4_bin NOT NULL COMMENT '标识',
  `name` varchar(255) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '名称',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL COMMENT '描述',
  `is_deleted` TINYINT (4) COMMENT '是否删除',
  `created_date` DATETIME COMMENT '创建时间',
  `latest_updated_date` DATETIME COMMENT '最近更新时间',
  `created_account_id` VARCHAR (36) COMMENT '创建账号id',
  `latest_updated_account_id` VARCHAR (36) COMMENT '最近更新账号id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;