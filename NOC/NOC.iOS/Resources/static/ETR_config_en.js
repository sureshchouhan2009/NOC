var config_en = {
    "lang": "en",
    "map_settings": {
        "basemap": "topo-vector",
        "center": [
            56.3160688,
            24.7104743
        ],
        "zoom": 7,
        "max-Scale": 4622325,
        "spatialReference": 4326,
        "extent": {
            "xmin": 5331040.891179526,
            "ymin": 2595626.106211735,
            "xmax": 7207111.313410394,
            "ymax": 3084823.087236733,
            "spatialReference": {
                "wkid": 102100
            }
        },
        "validationBuffer": { buffer: 3, units: "kilometers" }//meters/kilometers
    },
    "layerConfig": {
        "eLayers": [
            {
                "id": "mil_EtihadRailSpatial",
                "url": "https://portal.gpceast.com/server/rest/services/EtihadRail/EtihadRailSpatial/MapServer",
                "type": "MapImageLayer",
                "title": "EtihadRail Spatial",
                "key": "Viewing",
                "sublayers": [
                    {
                        "id": 3,
                        "visible": true,
                        "title": "ER Buffer",
                        "popupEnabled": true,
                        "popupTemplate": {
                            title: "ER Buffer",
                            content: "",
                            returnGeometry: true
                        },
                        "fields": [{ "name": "Name", "type": "string" },
                        { "name": "Date", "type": "date" },
                        { "name": "Version_Hi", "type": "string" }]
                    },
                    {
                        "id": 2,
                        "visible": true,
                        "title": "ER Land Boundary",
                        "popupEnabled": true,
                        "popupTemplate": {
                            title: "ER Land Boundary",
                            content: "",
                            returnGeometry: true
                        },
                        "fields": [{ "name": "Usage_Type", "type": "string" },
                        { "name": "Build_Stat", "type": "string" },
                        { "name": "ER_Stage", "type": "string" },
                        { "name": "ER_Package", "type": "string" },
                        { "name": "Version_Hi", "type": "string" },
                        { "name": "Remarks", "type": "string" },
                        { "name": "Name", "type": "string" },
                        { "name": "Date", "type": "date" },]
                    },
                    {
                        "id": 0,
                        "visible": true,
                        "title": "ER Alignment Segment",
                        "popupEnabled": true,
                        "popupTemplate": {
                            title: "ER Alignment Segment",
                            content: "",
                            returnGeometry: true
                        },
                        "fields": [{ "name": "EtihadRail.ERS.Alignment_Segment.Entity", "type": "string" },
                        { "name": "Layer", "type": "string" },
                        { "name": "Color", "type": "integer" },
                        { "name": "Linetype", "type": "string" },
                        { "name": "Elevation", "type": "double" },
                        { "name": "LineWt", "type": "integer" },
                        { "name": "RefName", "type": "string" },
                        { "name": "RAGGIO", "type": "string" },
                        { "name": "VELOCITA", "type": "string" },
                        { "name": "MCP", "type": "string" }
                        ]
                    },
                    {
                        "id": 1,
                        "visible": true,
                        "title": "ER Alignment",
                        "popupEnabled": true,
                        "popupTemplate": {
                            title: "ER Alignment",
                            content: "",
                            returnGeometry: true
                        },
                        "fields": [{ "name": "ER_Stage", "type": "string" },
                        { "name": "Version_Hi", "type": "string" },
                        { "name": "Remarks", "type": "string" },
                        { "name": "Date", "type": "date" },
                        { "name": "Build_Status", "type": "string" }]
                    }
                ],
                "visible": true,
                "addToMap": true,
                "opacity": 1,
                "useToken": false,
                "ConflictValidation": true// this is for validateConflictStatus_Spatial -> in spatialqueryvalidations.js
            },
            {
                "id": "mil_EtihadRailProjectArea",
                "url": "https://portal.gpceast.com/server/rest/services/EtihadRail/EtihadRailProjectArea/MapServer",
                "type": "MapImageLayer",
                "title": "Project Area",
                "key": "Viewing",
                "sublayers": [
                    {
                        "id": 0,
                        "visible": true,
                        "title": "Project Area",
                        "popupEnabled": true,
                        "popupTemplate": {
                            title: "Project Area",
                            content: "",
                            returnGeometry: true
                        },
                        "fields": [
                            { name: 'OBJECTID', type: 'oid', label: 'OBJECTID' },
                            { name: 'TRANSACTIONID', type: 'string', label: 'TransactionID' },
                            { name: 'PROJECTOWNER', type: 'string', label: 'ProjectOwner' },
                            { name: 'PROJECTCODE', type: 'string', label: 'Project Code' },
                            { name: 'PROJECTNAME', type: 'string', label: 'Project Name' },
                            { name: 'PROJECTDESC', type: 'string', label: 'Project Desc' },
                            { name: 'PROJECTMANAGER_ENGINEER', type: 'string', label: 'ProjectManager_Engineer' },
                            { name: 'PROJECTCONSULTANT', type: 'string', label: 'ProjectConsultant' },
                            { name: 'PROJECTCONTRACTOR', type: 'string', label: 'ProjectContractor' },
                            { name: 'PROJECTSTARTDATE', type: 'date', label: 'ProjectStartDate' },
                            { name: 'PROJECTFINISHDATE', type: 'date', label: 'ProjectFinishDate' },
                            { name: 'ROLEID', type: 'string', label: 'ROLEID' },
                            { name: 'USER_ID', type: 'string', label: 'UserID' },
                            { name: 'EMIRATENAME', type: 'string', label: 'EMIRATENAME' },
                            { name: 'REGIONNAME', type: 'string', label: 'REGIONNAME' },
                            { name: 'SECTORNAME', type: 'string', label: 'SECTORNAME' },
                            { name: 'SERVICEAREA', type: 'string', label: 'SERVICEAREA' },
                            { name: 'CENTER_X', type: 'double', label: 'CENTER_X' },
                            { name: 'CENTER_Y', type: 'double', label: 'CENTER_Y' },
                            { name: 'ISACTIVE', type: 'integer', label: 'ISACTIVE' },
                            { name: 'PROJECTBUFFER', type: 'integer', label: 'PROJECTBUFFER' },
                            { name: 'PROJECTTYPE', type: 'string', label: 'PROJECTTYPE' }
                            //{ name: 'Conflict', type: 'integer', label: 'Conflict' }
                        ]
                    }
                ],
                "visible": true,
                "addToMap": true,
                "opacity": 1,
                "useToken": false
            },
            {
                "id": "fl_EtihadRailProjectArea",
                "url": "https://portal.gpceast.com/server/rest/services/EtihadRail/EtihadRailProjectArea/FeatureServer/0",
                "type": "FeatureLayer",
                "title": "Project Area",
                "key": "Editing",
                "visible": false,
                "addToMap": false,
                "opacity": 1,
                "attributeFields": [
                    "*"
                ],
                "infoWindow": {
                    "active": true,
                    "field": [
                        "*"
                    ]
                },
                "useToken": false
            },
            {
                "id": "mil_AdministrativeUnitsER",
                "url": "https://gisstg.etihadrail.ae/arcgis/rest/services/ExternalData/Administrative_Layers/MapServer",
                "type": "MapImageLayer",
                "title": "Administrative Units ER",
                "key": "Validation",
                "Why_This_Service": "Validation for project boundary creating within in National boundary (sublayer-2)",
                "sublayers": [
                    {
                        "id": 1,
                        "visible": true,
                        "title": "City Boundary",
                        "popupEnabled": false,
                    },
                    {
                        "id": 2,
                        "visible": true,
                        "title": "District",
                        "popupEnabled": false,
                    },
                    {
                        "id": 3,
                        "visible": true,
                        "title": "Emirates",
                        "popupEnabled": false,
                    }
                ],
                "visible": false,
                "addToMap": false,
                "opacity": 1,
                "useToken": false,
                "validationLayerID": 2
            },
            {
                "id": "mil_AdministrativeUnitsFCSC",
                "url": "https://gisstg.etihadrail.ae/arcgis/rest/services/PublishedServices/AdministrativeUnitsFCSC/MapServer",
                "type": "MapImageLayer",
                "title": "Administrative Units FCSC",
                "key": "Validation",
                "Why_This_Service": "Spatial query for getting REGIONNAME , EMIRATENAME values insert to project boundary",
                "sublayers": [
                    {
                        "id": 8,
                        "visible": true,
                        "title": "SubDistrict",
                        "popupEnabled": false,
                    },
                    {
                        "id": 3,
                        "visible": true,
                        "title": "District",
                        "popupEnabled": false,
                    },
                    {
                        "id": 7,
                        "visible": true,
                        "title": "Municipalities",
                        "popupEnabled": false,
                    },
                    {
                        "id": 6,
                        "visible": true,
                        "title": "Emirates",
                        "popupEnabled": false,
                    }
                ],
                "visible": false,
                "addToMap": false,
                "opacity": 1,
                "useToken": false
            },
            {
                "id": "mil_ER_NOC_Spatial_BR",
                "url": "https://portal.gpceast.com/server/rest/services/EtihadRail/eNOCLandBoundary/MapServer",
                "type": "MapImageLayer",
                "title": "ER NOC patial BR",
                "key": "Validation",
                "Why_This_Service": "Spatial query for getting [Buffertype, Alignment Name, Alignnment Main Code, AssetStage] values insert to Business table",
                "sublayers": [
                    {
                        "id": 0,
                        "visible": true,
                        "title": "eNOC_Land_Boundary",
                        "popupEnabled": false,
                    }
                ],
                "visible": false,
                "addToMap": false,
                "opacity": 1,
                "useToken": false,
                "Business_Validation": {
                    "fields": [],
                    "tolerance": 1
                }
            }
        ],
        "gLayers": [
            {
                "id": "grl_sketch",
                "type": "GraphicsLayer",
                "title": "Sketch Graphics Layer",
                "key": "",
                "visible": true,
                "addToMap": false,
                "opacity": 1,
                "attributeFields": [
                    "*"
                ],
                "infoWindow": {
                    "active": false,
                    "field": [
                        "*"
                    ]
                },
                "symbol": {
                    "pointSymbol": {
                        "type": "simple-marker",
                        "style": "circle",
                        "size": 6,
                        "color": [
                            255,
                            255,
                            255,
                            0.8
                        ],
                        "outline": {
                            "color": [
                                211,
                                132,
                                80,
                                0.7
                            ],
                            "size": 3
                        }
                    },
                    "polylineSymbol": {
                        "type": "simple-line",
                        "color": [
                            211,
                            132,
                            80,
                            0.7
                        ],
                        "width": 3
                    },
                    "polygonSymbol": {
                        "type": "simple-fill",
                        "color": [
                            51,
                            51,
                            204,
                            0.9
                        ],
                        "style": "solid",
                        "outline": {
                            "color": "white",
                            "width": 3
                        }
                    }
                },
                "useToken": false
            },
            {
                "id": "grl_drawBuffer",
                "type": "GraphicsLayer",
                "title": "Buffer Graphics Layer",
                "key": "",
                "visible": true,
                "addToMap": true,
                "opacity": 1,
                "attributeFields": [
                    "*"
                ],
                "infoWindow": {
                    "active": false,
                    "field": [
                        "*"
                    ]
                },
                "symbol": {
                    "pointSymbol": {
                        "type": "simple-marker",
                        "style": "circle",
                        "size": 5,
                        "color": [
                            255,
                            255,
                            255,
                            0.8
                        ],
                        "outline": {
                            "color": [
                                211,
                                132,
                                80,
                                0.7
                            ],
                            "size": 3
                        }
                    },
                    "polylineSymbol": {
                        "type": "simple-line",
                        "color": [
                            211,
                            132,
                            80,
                            0.7
                        ],
                        "width": 3
                    },
                    "polygonSymbol": {
                        "type": "simple-fill",
                        "color": [
                            51,
                            51,
                            0,
                            0.4
                        ],
                        "style": "solid",
                        "outline": {
                            "color": "white",
                            "width": 3
                        }
                    }
                },
                "useToken": false
            },
            {
                "id": "grl_draw",
                "type": "GraphicsLayer",
                "title": "Sketch Graphics Layer",
                "key": "",
                "visible": true,
                "addToMap": true,
                "opacity": 1,
                "attributeFields": [
                    "*"
                ],
                "infoWindow": {
                    "active": false,
                    "field": [
                        "*"
                    ]
                },
                "symbol": {
                    "pointSymbol": {
                        "type": "simple-marker",
                        "style": "circle",
                        "size": 5,
                        "color": [
                            255,
                            255,
                            255,
                            0.8
                        ],
                        "outline": {
                            "color": [
                                211,
                                132,
                                80,
                                0.7
                            ],
                            "size": 3
                        }
                    },
                    "polylineSymbol": {
                        "type": "simple-line",
                        "color": [
                            211,
                            132,
                            80,
                            0.7
                        ],
                        "width": 3
                    },
                    "polygonSymbol": {
                        "type": "simple-fill",
                        "color": [
                            211,
                            132,
                            80,
                            0.7
                        ],
                        "style": "solid",
                        "outline": {
                            "color": "white",
                            "width": 3
                        }
                    }
                },
                "useToken": false
            }
        ],
        "basemap_Layers": [
            {
                "id": "satellite",
                "url": "https://services.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer",
                "thumbnail": "",
                "include": true,
                "title": "satellite",
                "key": "satellite",
                "useToken": false
            },
            {
                "id": "streets",
                "url": "https://services.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer",
                "thumbnail": "",
                "include": true,
                "title": "streets",
                "key": "streets",
                "useToken": false
            },
            {
                "id": "topo",
                "url": "https://services.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer",
                "thumbnail": "",
                "include": true,
                "title": "topo",
                "key": "topo",
                "useToken": false
            }
        ],
        //[projectFLayer] This is used for create or edit project boundaries"
        "projectFLayer": "https://portal.gpceast.com/server/rest/services/EtihadRail/EtihadRailProjectArea/FeatureServer/0",
        "ER_NOC_Spatial_BR": "https://portal.gpceast.com/server/rest/services/EtihadRail/eNOCLandBoundary/MapServer",
        "Edit_fields": {
            "TRANSACTIONID": "TRANSACTIONID",
            "REGIONNAME": "REGIONNAME",// municipality name
            "x": "CENTER_X",
            "y": "CENTER_Y",
            "EMIRATENAME": "EMIRATENAME",
            "Conflict": "Conflict"
        },
        "fields": {
            "TRANSACTIONID": "TRANSACTIONID",
            "REGIONNAME": "REGIONNAME",// municipality name
            "x": "CENTER_X",
            "y": "CENTER_Y",
            "EMIRATENAME": "EMIRATENAME",
            "Conflict": "Conflict",

            "MUNICIPALITY_ID": "MUNICIPALITYID",
            "MUNICIPALITY_NAME": "NAMEEN",
            "EMIRATE_NAME": "NAMEEN",
            "EMIRATE_ID": "EMIRATEID"
        },
        "GP_Services": {
            "Upload_CAD_JSON": {
                "uploadzip_url": "https://portal.gpceast.com/server/rest/services/BAP/CAD2GeoJsonGP/GPServer/uploads/upload",
                "submitjob_url": "https://portal.gpceast.com/server/rest/services/BAP/CAD2GeoJsonGP/GPServer/CAD2GeoJson",
                "fields": []
            },
            "Upload_GDB_JSON": {},
            "JSON_to_ESRI_Format": {
                "url": "https://portal.gpceast.com/server/rest/services/EtihadRail/JSONToFeature/GPServer/JsonToFeature",
                "input_parameters": {
                    "gisformat": "GIS_FORMAT",
                    "feature": "FEATURE",
                    "featureFormat": {
                        "displayFieldName": "",
                        "geometryType": "esriGeometryPolygon",
                        "spatialReference": {
                            "wkid": 4326,
                            "latestWkid": 4326
                        },
                        "fields": [
                            {
                                "name": "OBJECTID",
                                "type": "esriFieldTypeOID",
                                "alias": "OBJECTID"
                            },
                            {
                                "name": "SHAPE_Length",
                                "type": "esriFieldTypeDouble",
                                "alias": "SHAPE_Length"
                            },
                            {
                                "name": "SHAPE_Area",
                                "type": "esriFieldTypeDouble",
                                "alias": "SHAPE_Area"
                            }
                        ],
                        "features": [{
                            "attributes": {
                                "OBJECTID": 1,
                                "SHAPE_Area": 2.4654672664176501e-05,
                                "SHAPE_Length": 0.020803975068928202
                            },
                            "geometry": {
                                "rings": []
                            }
                        }],
                        "exceededTransferLimit": false
                    }
                }
            }
        },
        "Token_Services": {
            "ER_GIS": "https://gisstg.etihadrail.ae/arcgis/rest/services"
        },
        "SearchServices": {
            "AddProject": {
                "url": "https://onwani.abudhabi.ae/arcgis/rest/services/MSSI/ADMINBOUNDARIES/MapServer/0",
                "type": "FeatureLayer",
                "title": "PLOTS",
                "key": "Search_AddProject",
                "Why_This_Service": "load this service for search plots to create new project from selected plot",
                "includeDefaultSources": false,
                "placeholder": "Plot",
                "singleLineFieldName": "SingleLineFieldName",
                "maxResults": 6,
                "maxSuggestions": 6,
                "suggestionsEnabled": true,
                "minSuggestCharacters": 0,
                "exactMatch": false,
                "searchFields": ["PLOTID", "PLOTNUMBER"],
                "displayField": "PLOTID",
                "outFields": ["*"],
                "searchTemplate": "{PLOTID}, {DISTRICTENG}, {MunicipalityName}",
                "suggestionTemplate": "{PLOTID}, {DISTRICTENG}, {MunicipalityName}"
            }
        },
        "Other_Aditionals": {
            "BusinesRuleValidation": {
                "url": "https://portal.gpceast.com/server/rest/services/EtihadRail/eNOCLandBoundary/MapServer",
                "title": "ER_NOC_Spatial_BR",
                "fields": ["Usage_Type", "Build_Stat", "ER_Stage", "ER_Package", "AlignmentNameEN", "AlignmentMainCode", "PMC", "Consultant", "Contractor"],
                "tolerance": 1,
                "bufferVal": 200,
                "bufferUnits": "meters",
                "layerOption": "all"
            },
        }
    },
    "en_ar-words": {
        "mapLoading": "Please wait MAP is loading",
        "zoomIn": "Rectangular Zoom In",
        "zoomOut": "Rectangular Zoom Out",
        "fullExtent": "Full Extent",
        "projectExtent": "Project Extent",
        "pan": "Pan",
        "TOC": "TOC",
        "BasemapGallery": "Basemap Gallery",
        "Measurement": "Measurement",
        "drawing": "Drawing",
        "layerList": "Layer List",
        "sketch": "Sketch",
        "legend": "Legend",
        "Edit": "Editor",
        "DrawProject": "Draw Project",
        "point": "Point",
        "polyline": "Polyline",
        "polygon": "Polygon",
        "buffer": "Buffer",
        "ApplyBuffer": "Apply Buffer",
        "SaveToFeature": "Save",
        "ResetSketch": "Clear",
        "AddFeature": "Add Project",
        "EditFeature": "Edit Project",
        "projectNotAvailable": "Project area not available, \n do you want to create new project area",
        "projectAreaCalling": "Loading project area",
        "backToDraw": "Back To Draw",
        "drawLimitExceeded": "Buffer value exceeded. Max value is ",
        "ClearMeasurements": "Clear Measurements",
        "AreaMeasurementTool": "Area Measurement Tool",
        "DistanceMeasurementTool": "Distance Measurement Tool",
        "URL": "Reference",
        "AddESRI_URLs": "Add ESRI REST services",
        "AddToMap": "Add to Map",
        "EnterURL": "ESRI REST URL",
        "LoadESRIservice": "Layer adding to MAP",
        "RefLayers": "Reference Layers",
        "PleaseEnterESRI_REST_Services": "Please Enter ESRI REST Services",
        "ServiceIsNotSupport": "Service is not support",
        "layerIndexMissing": "This is FeatureService use layer index in URL last place",
        "ServiceLoadingError": "Service loading error",
        "ExtractProject": "Export Project Boundary",
        "Export": "Export",
        "SelectGISFormate": "Select Output GIS Formate",
        "DownloadingProjectBoundary": "Downloading Project...",
        "DrawingProjectOutOfAdmin": "Project boundary not with in the Administrative Units",
        "ProjectBoundaryOutOfEmirate": "New Project location is moved from '@E' to '@N', Moving project location across the emirtes are not allowed.\n Please create new transaction for the new location",
        "UploadFileNotSupport": "Uploaded file not support, file should be .zip",
        "FileUploading": "File Uploading...",
        "FileUploadingFailed": "File Uploading Failed",
        "listOfAllowedLayers": ["projectarea", "project area", "project boundary", "projectboundary"],
        "UploadFileNamesMust": "Upload failed, due to layer name not match with template. Layer name should be either ",
        "ProjectionWrong": "Uploaded Spatial Data should be 'WKID : 4326' (SpatialReference)",
        "DrawSketch": "Draw Sketch",
        "UploadFile": "Upload File",
        "or": "or",
        "AddProjectbyVertex": "Add Project by Coordinates",
        "SpatialReference": "Spatial Reference",
        "undo": "Undo Vertex",
        "addVertex": "Add Vertex",
        "LayerLoadingError": "Duet to technical issue unable to load the service : ",
        "AddProjectbysearch": "Add Project by Search",
    },
    "react_Settings": {
        "Dialog": {
            "width": "18vw",
            "marginLeft": "3%",
            "draggable": true,
            "resizable": false,
            "position": "top-left",
            "rtl": false
        },
        "theme": {
            "color": "rgba(167,28,7,255)"
        },
        "icons": {
            "height": "25px",
            "width": "25px"
        },
        "ProjectEditor": {
            "buffer_input": {
                "min": 0,
                "max": 100
            }
        },
        "navTools": {
            "position": "top-right"
        },
        "CustomSearch": {
            "position": "bottom-left",
            "rtl": false
        },
        "Measurement": {
            "AreaUnit": "square-meters",
            "LengthUnit": "meters"
        }
    }
}