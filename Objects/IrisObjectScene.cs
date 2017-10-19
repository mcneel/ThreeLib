using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Specialized;
using System;

namespace IrisLib
{
    /// <summary>
    /// This class represents the entire model as a Three.js JSON Object Scene format 4. It includes methods to add different kind of objects to the scene.
    /// This object can be converted to JSON by running the .ToJSON() method.
    /// See https://github.com/mrdoob/three.js/wiki/JSON-Object-Scene-format-4 for a reference.
    /// </summary>
    public class IrisScene
    {
        /// <summary>
        /// Metadata for the model.
        /// </summary>
        [JsonProperty("metadata")]
        public IrisMetadata Metadata { get; set; }

        /// <summary>
        /// The collection of fonts used by text objects in the model.
        /// </summary>
        [JsonProperty("fonts")]
        public IrisFontCollection Fonts { get; set; }

        /// <summary>
        /// The collection of geometries used in the model.
        /// </summary>
        [JsonProperty("geometries")]
        public IList<IIrisElement> Geometries { get; set; }

        /// <summary>
        /// The collection of images used by textures in the model.
        /// </summary>
        [JsonProperty("images")]
        public IrisImageCollection Images { get; set; }

        /// <summary>
        /// The collection of textures used by materials in the model.
        /// </summary>
        [JsonProperty("textures")]
        public IrisTextureCollection Textures { get; set; }

        /// <summary>
        /// The collection of materials used by objects in the model.
        /// </summary>
        [JsonProperty("materials")]
        public List<IIrisMaterial> Materials { get; set; }

        /// <summary>
        /// The collection of objects in the model. Objects may contain a geometry, a material, and user data.
        /// </summary>
        [JsonProperty("object")]
        public IrisSceneObject @Object { get; set; }

        [JsonIgnore]
        private IrisLineMaterialCollection lineMaterialCollection;
        [JsonIgnore]
        private IrisPointCloudMaterialCollection pointcloudMaterialCollection;
        [JsonIgnore]
        private IrisPhongMaterialCollection phongMaterialCollection;
        [JsonIgnore]
        private IrisLambertMaterialCollection lambertMaterialCollection;
        [JsonIgnore]
        private IrisBasicMaterialCollection basicMaterialCollection;
        [JsonIgnore]
        private IrisStandardMaterialCollection standardMaterialCollection;

        [JsonIgnore]
        private List<IrisObjectCPlane> planes;
        [JsonIgnore]
        private IrisLayerCollection layers;
        [JsonIgnore]
        private List<IrisObjectPosition> positions;
        [JsonIgnore]
        private List<IrisObjectGroup> groups;


        /// <summary>
        /// Initialize a new IrisScene.
        /// </summary>
        public IrisScene()
        {
            Metadata = new IrisMetadata();
            Fonts = new IrisFontCollection();
            Geometries = new List<IIrisElement>();
            Images = new IrisImageCollection();
            Textures = new IrisTextureCollection();
            Materials = new List<IIrisMaterial>();
            @Object = new IrisSceneObject();

            lineMaterialCollection = new IrisLineMaterialCollection();
            pointcloudMaterialCollection = new IrisPointCloudMaterialCollection();
            phongMaterialCollection = new IrisPhongMaterialCollection();
            lambertMaterialCollection = new IrisLambertMaterialCollection();
            basicMaterialCollection = new IrisBasicMaterialCollection();
            standardMaterialCollection = new IrisStandardMaterialCollection();

            planes = new List<IrisObjectCPlane>();
            layers = new IrisLayerCollection();
            positions = new List<IrisObjectPosition>();
            groups = new List<IrisObjectGroup>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        public void AddObject(IrisGeometry geometry, IrisMaterial material) { }

        /// <summary>
        /// Adds a mesh object to the scene.
        /// </summary>
        /// <param name="geometry">The IrisGeometry object containing the mesh data.</param>
        /// <param name="material">The mesh object's material.</param>
        /// <param name="id"></param>
        /// <param name="name">The mesh object's name.</param>
        /// <param name="layer">The mesh object's layer.</param>
        /// <param name="userDataObject">User Data attatched to the object.</param>
        /// <param name="userDataAttributes">User Data attatched to the object attributes.</param>
        public void AddMeshObject(IrisGeometry geometry, IrisMaterial material, Guid id, string name = "", IrisLayer layer = null, NameValueCollection userDataObject = null, NameValueCollection userDataAttributes = null)
        {
            if (geometry == null || geometry.Type != "Geometry") return;

            Geometries.Add(geometry);

            var matId = Guid.Empty;

            if (material is IrisPhongMaterial)
                matId = phongMaterialCollection.AddIfNew(material as IrisPhongMaterial);
            else if (material is IrisLambertMaterial)
                matId = lambertMaterialCollection.AddIfNew(material as IrisLambertMaterial);
            else if (material is IrisStandardMaterial)
                matId = standardMaterialCollection.AddIfNew(material as IrisStandardMaterial);
            else if (material == null)
            {
                material = new IrisStandardMaterial();
                matId = standardMaterialCollection.AddIfNew(material as IrisStandardMaterial);
            }

            var mesh = new IrisObjectMesh(geometry.Uuid, matId, name, layer.FullPath, userDataObject, userDataAttributes);
            mesh.SetId(id);

            AddLayer(layer);

            @Object.Children.Add(mesh);

        }

        /// <summary>
        /// Adds a curve object to the scene.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="id"></param>
        /// <param name="layer"></param>
        /// <param name="userDataObject"></param>
        /// <param name="userDataAttributes"></param>
        /// <param name="userDataCurve"></param>
        public void AddCurveObject(IrisGeometry geometry, IrisLineMaterial material, Guid id, IrisLayer layer = null, NameValueCollection userDataObject = null, NameValueCollection userDataAttributes = null, Dictionary<string, object> userDataCurve = null)
        {
            if (geometry == null || geometry.Type != "Geometry") return;

            Geometries.Add(geometry);

            if (material == null)
                material = new IrisLineMaterial();
            var matId = lineMaterialCollection.AddIfNew(material);

            var curve = new IrisObjectCurve(geometry.Uuid, matId, layer.FullPath, userDataObject, userDataAttributes);
            curve.SetId(id);
            if(userDataCurve != null)
                curve.UserData.Add("Curve", userDataCurve);

            AddLayer(layer);

            @Object.Children.Add(curve);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="layer"></param>
        /// <param name="userDataObject"></param>
        /// <param name="userDataAttributes"></param>
        public void AddPointsObject(IrisGeometryBuffer geometry, IrisPointCloudMaterial material, IrisLayer layer = null, NameValueCollection userDataObject = null, NameValueCollection userDataAttributes = null)
        {
            if (geometry == null || geometry.Type != "BufferGeometry") return;

            if (material == null)
                material = new IrisPointCloudMaterial();

            Geometries.Add(geometry);

            var matId = pointcloudMaterialCollection.AddIfNew(material as IrisPointCloudMaterial);

            var points = new IrisObjectPoints(geometry.Uuid, material.Uuid, layer.FullPath, userDataObject, userDataAttributes);
            @Object.Children.Add(points);
        }

        /// <summary>
        /// Adds a light to the scene.
        /// </summary>
        /// <param name="light">The Point, Spot, or Directional light to add.</param>
        public void AddLightObject(IrisObjectLight light)
        {
            if (light == null || !light.Type.Contains("Light")) return;

            if(light is IrisObjectPointLight)
                @Object.Children.Add(light as IrisObjectPointLight);
            if(light is IrisObjectSpotLight)
                @Object.Children.Add(light as IrisObjectSpotLight);
            if (light is IrisObjectDirectionalLight)
                @Object.Children.Add(light as IrisObjectDirectionalLight);
        }

        /// <summary>
        /// Add an Orthographic or Perspective camera to the scene.
        /// </summary>
        /// <param name="camera">The perspective or orthographic camera to add.</param>
        public void AddCameraObject(IrisElement camera)
        {
            if (camera == null || !camera.Type.Contains("Camera")) return;

            if(camera is IrisObjectPerspectiveCamera)
                @Object.Children.Add(camera as IrisObjectPerspectiveCamera);
            if (camera is IrisObjectOrthographicCamera)
                @Object.Children.Add(camera as IrisObjectOrthographicCamera);

        }

        /// <summary>
        /// 
        /// </summary>
        public void AddGroupObject(IrisObjectGroup group, IrisLayer layer)
        {
            AddLayer(layer);
            groups.Add(group);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="groupId"></param>
        public void AddObjectToGroup(IrisElement obj, Guid groupId)
        {
            groups.Find(g => g.Uuid == groupId).Children.Add(obj);
        }

        /// <summary>
        /// Adds a material to the scene.
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public Guid AddMaterial(IrisMaterial material)
        {
            var matId = Guid.Empty;

            if (material is IrisPhongMaterial)
                matId = phongMaterialCollection.AddIfNew(material as IrisPhongMaterial);
            else if (material is IrisLambertMaterial)
                matId = lambertMaterialCollection.AddIfNew(material as IrisLambertMaterial);
            else if (material is IrisStandardMaterial)
                matId = standardMaterialCollection.AddIfNew(material as IrisStandardMaterial);
            else if (material is IrisLineMaterial)
                matId = lineMaterialCollection.AddIfNew(material as IrisLineMaterial);

            return matId;
        }

        /// <summary>
        /// Adds a Clipping Plane object to the scene.
        /// </summary>
        /// <param name="plane">The Clipping Plane.</param>
        public void AddPlaneObject(IrisObjectCPlane plane)
        {
            planes.Add(plane);
        }

        /// <summary>
        /// Adds a layer to the scene. This should only be called by the Adders.
        /// </summary>
        /// <param name="layer">The layer to be added.</param>
        private void AddLayer(IrisLayer layer)
        {
            layers.AddIfNew(layer);
        }

        /// <summary>
        /// Adds a position to the scene. A position contains an array of transform matrices and related object Guids.
        /// </summary>
        /// <param name="position">The position to add.</param>
        public void AddPosition(IrisObjectPosition position)
        {
            positions.Add(position);
        }

        /// <summary>
        /// Adds an image to the scene.
        /// </summary>
        /// <param name="image">IrisImage to add.</param>
        /// <returns></returns>
        public Guid AddImage(IrisImage image)
        {
            return Images.AddIfNew(image);
        }

        /// <summary>
        /// Adds texture to the scene.
        /// </summary>
        /// <param name="texture">Iris Texture to add.</param>
        /// <returns></returns>
        public Guid AddTexture(IrisTexture texture)
        {
            return Textures.AddIfNew(texture);
        }

        /// <summary>
        /// Serializes the Iris Scene into a JSON string.
        /// </summary>
        /// <returns>A Three.js compatible Scene Object Format JSON string.</returns>
        public string ToJSON()
        {

            Materials = new List<IIrisMaterial>();
            Materials.AddRange(lineMaterialCollection);
            Materials.AddRange(pointcloudMaterialCollection);
            Materials.AddRange(phongMaterialCollection);
            Materials.AddRange(lambertMaterialCollection);
            Materials.AddRange(basicMaterialCollection);
            Materials.AddRange(standardMaterialCollection);

            @Object.WritePlanes(planes);
            @Object.WriteLayers(layers);
            @Object.WritePositions(positions);

            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
        }

    }

    /// <summary>
    /// This contains all of the objects in the scene as well as any user data.
    /// </summary>
    public class IrisSceneObject : IrisElement
    {
        /// <summary>
        /// Scene name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The orientation matrix for this scene.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        /// <summary>
        /// The collection of objects in this scene.
        /// </summary>
        [JsonProperty("children")]
        public IList<IIrisElement> Children { get; set; }

        /// <summary>
        /// The scene background color as an rgb int.
        /// </summary>
        [JsonProperty("background", DefaultValueHandling = DefaultValueHandling.Include)]
        public int BackgroundColor { get; set; }

        /// <summary>
        /// A collection of data to be included with the scene object.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; private set; }

        /// <summary>
        /// Initialize a new IrisSceneObject.
        /// </summary>
        public IrisSceneObject()
        {
            Type = "Scene";

            BackgroundColor = 16777215;

            Children = new List<IIrisElement>();

            UserData = new Dictionary<string, Dictionary<string, object>>();
        }
        
        /// <summary>
        /// Write CPlanes to user data.
        /// </summary>
        /// <param name="planes">The collection of planes to add.</param>
        public void WritePlanes(IEnumerable<IIrisElement> planes)
        {
            if (planes.ToList().Count == 0 || planes == null) return;

            var userData = new Dictionary<string, object>();
            int cnt = 1;

            foreach (var plane in planes)
            {
                var pln = (IrisObjectCPlane)plane;
                if (pln.Name == "" || pln.Name == string.Empty) {
                    pln.SetName("Plane_" + cnt);
                    cnt++;
                }
                userData.Add(pln.Name, pln);
            }

            UserData.Add("Planes",userData);
        }

        /// <summary>
        /// Write Layers to user data.
        /// </summary>
        /// <param name="layers">The collection of layers to add.</param>
        public void WriteLayers(IrisLayerCollection layers)
        {

            if (layers.Count == 0 || layers == null) return;

            var userData = new Dictionary<string, object>();

            foreach (var layer in layers.OrderBy(l => l.SortIndex).ToList())
                if(!userData.ContainsKey(layer.FullPath))
                    userData.Add(layer.FullPath, layer.IsVisible);

            if(!UserData.ContainsKey("Layers"))
                UserData.Add("Layers", userData);
        }

        /// <summary>
        /// Write Positions to user data.
        /// </summary>
        /// <param name="positions">The collection of positions to add.</param>
        public void WritePositions(List<IrisObjectPosition> positions)
        {
            if (positions == null || positions.Count == 0) return;
            var userData = new Dictionary<string, object>();

            foreach (var position in positions)
            {
                userData.Add(position.Name, position);
            }

            UserData.Add("Positions", userData);
        }

    }
}



