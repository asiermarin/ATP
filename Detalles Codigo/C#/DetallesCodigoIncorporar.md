### Return abreviado

```
private _provider;
```
Forma larga:

```
public string SomethingWithString(string oneString)
{
    return _provider.OneMethodWithString(oneString);
}
```
Forma abreviada:

```
public string SomethingWithString(string oneString) =>
    _provider.OneMethodWithString(oneString);
```
### Get y set personalizado

```
public string ConnectionString
        {
            get { return connectionString ?? ConnectionStringFromEnv; }
            set { connectionString = value; }
        }
```
El operdor ?? evalua si el operando izquierdo (connectionString) es null.
 - Si connectionString != null devuelve ese mismo valor.
 - Sí connectionString == null devuelve ConnectionStringFromEnv

Sería algo como:

```
if (connectionString != null)
{
    return connectionString;
}
else if(connectionString == null)
{
    return ConnectionStringFromEnv;
}
```

Nota: Sí connectionString no es null no evaluará el operando derecho (ConnectionStringFromEnv).
```
a ?? b ?? c
d ??= e ??= f
```
Se evalúa como:
```
a ?? (b ?? c)
d ??= (e ??= f)
```

### Métodos con argumentos personalizados

De primeras algún argumento debe ser null de entrada para que sea válido. O en un estado determinado como queramos sí es booleano.

```
public void SomeMethod(string argument1, string argument2 = null, bool boolArguent = false)
{
    // Do something with arguments
}
```
### SingleOrDefault()

Retorna un elemento sólo o el predetermiando (cual es?). Para objetos list o DbSet entre otros.

### Los Forech

Existen dos formas de hacerlo, la forma más evidente;

```
foreach (var coordenada in _listaCoordenadasIII)
            {
                if (coordenada.YaUtilizada == false) 
                {
                    Mu newMu = new Mu(NuevaCadenaReglaTres(coordenada, mu), regla, mu.Historial);
                    listMuSustituido.Add(newMu);
                }
            }
```

Y la forma de utilizar un método:

```
_listaCoordenadasIII.ForEach(x =>
            {
                if (x.YaUtilizada == false)
                {
                    Mu newMu = new Mu(NuevaCadenaReglaTres(x, mu), regla, mu.Historial);
                    listMuSustituido.Add(newMu);

                    _listaCoordenadasIII.Remove(x);
                }
            });
```

El punto positivo de utilizar ésta forma es que no utiliza un objeto de tipo Enumerator para recorrerlo. Eso nos permite utilizar el método Remove() sí queremos utilizarlo.

### Clonar listas de manera elegante: AddRange()
```
unaLista.AddRange(otraLista);
```

Permite copiar de una lista a otra los objetos de su interior. Se puede tambien hacer copiar parametrizadas.

```
List<string> lstNew = lstTest.GetRange(0, 3);
```

En éste caso copiando los primeros 3 elementos.

### Nombres de funciones compuestos

El nombre de una función debe indicar que hace y devuelve:

```
    public void Authenticate_WhenVerificationHeaderIsFail_ShouldReturnFail()
    {
        Assert.IsFalse(something);
        Assert.IsNotNull(somethingElse);
    }
```
### Definición de string inicial

Si se crea un string pero no se sabe definir un valor en un principio:

```
string os = string.Empty;
```
### Variables de tipo bool?

Para untilizar un atributo de este tipo:

```
bool? IsTrue {get; set;}

if (obj.IsTrue.HasValue)
{

}
```
Hay que utilizar el atributo HasValue para utilizarlo como bool.

### Uso de constantes de manera inteligente

```
public static class ClaseConstantes1
    {
        public const string ESTO_ES_UNA_CONSTANTE = "CertificateHeaders";

        internal const string OTRA_CONSTANTE = "algo";

        public static class ClaseConstanteInterior
        {
            public const string CONSTANTE_INTERIOR = "algo2";
        }
    }
```
### Extensiones

´´´
public static class UnaClaseExtensions
    {
        public static ClaseModelo MetodoUnaClase(this UnaClase unaClase)
        {
            return new ClaseModelo
            {
                // Paso atributos
            };
        }
    }
´´´

Que conseguimos con esto? Ahora la clase UnaClase tiene un metodo como extensión (estáticas)
para una configuración generarica de una clase por ejemplo.

La clave es "this UnaClase unaClase" ya que es la manera en codigo de definir el metodo 
cuando haya una instacia de esa misma clase. Al ser estatico se puede llamar a la función
sin necesidad de instacia de la clase "UnaClaseExtensions".

var x = new UnaClase(); # Revisar, no puede haber un new con una clase estatica
x.MedotoUnaClase();