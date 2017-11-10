## `Image`

```csharp
public class THREE.Textures.Image
    : IEquatable<Image>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Exists | Image exists flag. | 
| `String` | OriginalPath | Image path. | 
| `String` | Url | Image url. This can be the path to the image resource (.jpg, .png, etc), or a base64 encoded asset. | 
| `Guid` | Uuid | Object Id. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`Image` other) |  | 
| `Int32` | GetHashCode() |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | GetDataURL(`String` imgFile) | Encode image to base64.  TODO: consider removing this to the example application. | 


## `ImageCollection`

```csharp
public class THREE.Textures.ImageCollection
    : Collection<Image>, IList<Image>, ICollection<Image>, IEnumerable<Image>, IEnumerable, IList, ICollection, IReadOnlyList<Image>, IReadOnlyCollection<Image>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Guid` | AddIfNew(`Image` item) | Add an Image to this collection if it does not already exist. | 


## `Texture`

```csharp
public class THREE.Textures.Texture
    : IEquatable<Texture>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Image` | Image | Image associated with this texture. | 
| `Nullable<Guid>` | ImageUuid | URL of the image. | 
| `Int32` | Mapping | Texture mapping. | 
| `Single[]` | Repeat | Texture repetition. | 
| `Guid` | Uuid | Object Id. | 
| `Int32[]` | Wrap | Texture wrapping. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`Texture` other) |  | 
| `Boolean` | Equals(`Object` other) |  | 
| `Int32` | GetHashCode() |  | 


## `TextureCollection`

```csharp
public class THREE.Textures.TextureCollection
    : Collection<Texture>, IList<Texture>, ICollection<Texture>, IEnumerable<Texture>, IEnumerable, IList, ICollection, IReadOnlyList<Texture>, IReadOnlyCollection<Texture>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Guid` | AddIfNew(`Texture` item) | Add a Texture to this collection if it does not already exist. | 


