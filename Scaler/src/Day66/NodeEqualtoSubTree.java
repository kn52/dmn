package Day66;

/*Given the root of a binary tree, return the number of nodes where the value of the node is equal to the average of the values in its subtree.

Note:

1. The average of n elements is the sum of the n elements divided by n and rounded down to the nearest integer.
2. A subtree of root is a tree consisting of root and all of its descendants.
*/
public class NodeEqualtoSubTree {
	int ans;
	
	public static void main(String[] args) {
		
	}
	
    public int averageOfSubtree(TreeNode root) {
        ans=0;
        traverse(root);
        return ans;
    }
   
    private int[] traverse(TreeNode root)
    {
        if(root==null)
            return new int[]{0,0};
        int[] left = traverse(root.left);
        int[] right = traverse(root.right);
        int sum = left[0]+right[0]+root.val;
        int cnt = left[1]+right[1]+1;
        if(sum/cnt==root.val){
            ans++;
        }
        return new int[]{sum,cnt};
    }
    
   
}
